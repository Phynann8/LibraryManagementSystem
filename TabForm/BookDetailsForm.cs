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
    public partial class BookDetailsForm : Form
    {
        // Connection string - same as in MainForm
        private string connectionString = "Server=CELESTIAL-WANNA\\PHYNANN;Database=LibraryDB;Integrated Security=True;TrustServerCertificate=True;";

        // This will be null for a new book, or hold the ID for a book being edited.
        private int? bookId;

        // Constructor for adding a NEW book
        public BookDetailsForm()
        {
            InitializeComponent();
            this.bookId = null;
            this.Text = "Add New Book";
            // **FIX:** Manually wire up the event handler to ensure it's connected.
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        // Constructor for EDITING an existing book
        public BookDetailsForm(int bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            this.Text = "Edit Book";
            // **FIX:** Manually wire up the event handler to ensure it's connected.
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            LoadBookData();
        }

        private void LoadBookData()
        {
            // If we are editing, load the book's current data from the DB
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ISBN, Title, Author FROM Books WHERE BookID = @BookID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookID", this.bookId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIsbn.Text = reader["ISBN"].ToString();
                            txtTitle.Text = reader["Title"].ToString();
                            txtAuthor.Text = reader["Author"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load book data. Error: " + ex.Message);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtIsbn.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (bookId == null)
                    {
                        // ADD MODE: Insert a new record
                        string query = "INSERT INTO Books (ISBN, Title, Author) VALUES (@ISBN, @Title, @Author)";
                        cmd = new SqlCommand(query, conn);
                    }
                    else
                    {
                        // EDIT MODE: Update an existing record
                        string query = "UPDATE Books SET ISBN = @ISBN, Title = @Title, Author = @Author WHERE BookID = @BookID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@BookID", this.bookId);
                    }

                    // Add parameters for both cases
                    cmd.Parameters.AddWithValue("@ISBN", txtIsbn.Text);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);

                    int result = cmd.ExecuteNonQuery();

                    // Check if the query was successful
                    if (result > 0)
                    {
                        MessageBox.Show("Book saved successfully!");
                        this.DialogResult = DialogResult.OK; // Set DialogResult to OK
                        this.Close(); // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Failed to save the book.");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle potential SQL errors, like a duplicate ISBN
                if (ex.Number == 2627) // Unique constraint error number
                {
                    MessageBox.Show("A book with this ISBN already exists. Please use a different ISBN.");
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
