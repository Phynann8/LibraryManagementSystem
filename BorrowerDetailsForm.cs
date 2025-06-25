using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class BorrowerDetailsForm : Form
    {
        // Connection string - must be the same as in other forms
        private string connectionString = "Server=CELESTIAL-WANNA\\PHYNANN;Database=LibraryDB;Integrated Security=True;TrustServerCertificate=True;";

        // This will be null for a new borrower, or hold the ID for a borrower being edited.
        private int? borrowerId;

        // Constructor for adding a NEW borrower
        public BorrowerDetailsForm()
        {
            InitializeComponent();
            this.borrowerId = null;
            this.Text = "Add New Borrower";
            // Manually wire up the event handler to ensure it's connected
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        // Constructor for EDITING an existing borrower
        public BorrowerDetailsForm(int borrowerId)
        {
            InitializeComponent();
            this.borrowerId = borrowerId;
            this.Text = "Edit Borrower";
            // Manually wire up the event handler to ensure it's connected
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            LoadBorrowerData();
        }

        private void LoadBorrowerData()
        {
            // If we are editing, load the borrower's current data from the DB
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FirstName, LastName, Email FROM Borrowers WHERE BorrowerID = @BorrowerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BorrowerID", this.borrowerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load borrower data. Error: " + ex.Message);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill in at least First Name and Last Name.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (borrowerId == null)
                    {
                        // ADD MODE: Insert a new record
                        string query = "INSERT INTO Borrowers (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
                        cmd = new SqlCommand(query, conn);
                    }
                    else
                    {
                        // EDIT MODE: Update an existing record
                        string query = "UPDATE Borrowers SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE BorrowerID = @BorrowerID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@BorrowerID", this.borrowerId);
                    }

                    // Add parameters for both cases
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Borrower saved successfully!");
                        this.DialogResult = DialogResult.OK; // Set DialogResult to OK
                        this.Close(); // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Failed to save the borrower.");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle potential SQL errors, like a duplicate email
                if (ex.Number == 2627) // Unique constraint error number
                {
                    MessageBox.Show("A borrower with this email already exists. Please use a different email.");
                }
                else
                {
                    MessageBox.Show("An error occurred while saving. Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. Error: " + ex.Message);
            }
        }
    }
}
