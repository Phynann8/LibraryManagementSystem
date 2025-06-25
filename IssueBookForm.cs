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
    public partial class IssueBookForm : Form
    {
        // Updated connection string with your server name
        private string connectionString = "Server=CELESTIAL-WANNA\\PHYNANN;Database=LibraryDB;Integrated Security=True;TrustServerCertificate=True;";

        public IssueBookForm()
        {
            InitializeComponent();
            // Wire up the events
            this.Load += new System.EventHandler(this.IssueBookForm_Load);
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
        }

        private void IssueBookForm_Load(object sender, EventArgs e)
        {
            // Load data into the dropdowns when the form opens
            LoadAvailableBooks();
            LoadBorrowers();
        }

        private void LoadAvailableBooks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Query to select ONLY available books
                    string query = "SELECT BookID, Title FROM Books WHERE IsAvailable = 1";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Configure the ComboBox
                    cmbBooks.DataSource = dt;
                    cmbBooks.DisplayMember = "Title"; // The text the user sees
                    cmbBooks.ValueMember = "BookID";  // The hidden value we will use
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load books. Error: " + ex.Message);
            }
        }

        private void LoadBorrowers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Query to get borrower's full name for display
                    string query = "SELECT BorrowerID, FirstName + ' ' + LastName AS FullName FROM Borrowers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Configure the ComboBox
                    cmbBorrowers.DataSource = dt;
                    cmbBorrowers.DisplayMember = "FullName"; // The text the user sees
                    cmbBorrowers.ValueMember = "BorrowerID"; // The hidden value we will use
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load borrowers. Error: " + ex.Message);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            // Validate that something is selected in both dropdowns
            if (cmbBooks.SelectedValue == null || cmbBorrowers.SelectedValue == null)
            {
                MessageBox.Show("Please select a book and a borrower.");
                return;
            }

            int bookId = (int)cmbBooks.SelectedValue;
            int borrowerId = (int)cmbBorrowers.SelectedValue;
            DateTime dateIssued = DateTime.Now;
            DateTime dateDue = dtpDueDate.Value;

            // Use a transaction to ensure both operations (insert loan and update book) succeed or fail together
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert the new loan record
                    string loanQuery = "INSERT INTO Loans (BookID, BorrowerID, DateIssued, DateDue) VALUES (@BookID, @BorrowerID, @DateIssued, @DateDue)";
                    SqlCommand loanCmd = new SqlCommand(loanQuery, conn, transaction);
                    loanCmd.Parameters.AddWithValue("@BookID", bookId);
                    loanCmd.Parameters.AddWithValue("@BorrowerID", borrowerId);
                    loanCmd.Parameters.AddWithValue("@DateIssued", dateIssued);
                    loanCmd.Parameters.AddWithValue("@DateDue", dateDue);
                    loanCmd.ExecuteNonQuery();

                    // 2. Update the book's availability status
                    string bookQuery = "UPDATE Books SET IsAvailable = 0 WHERE BookID = @BookID";
                    SqlCommand bookCmd = new SqlCommand(bookQuery, conn, transaction);
                    bookCmd.Parameters.AddWithValue("@BookID", bookId);
                    bookCmd.ExecuteNonQuery();

                    // If both commands succeed, commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Book issued successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    // If anything goes wrong, roll back the transaction
                    transaction.Rollback();
                    MessageBox.Show("Failed to issue book. Error: " + ex.Message);
                }
            }
        }
    }
}
