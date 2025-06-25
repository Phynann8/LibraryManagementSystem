using Microsoft.Data.SqlClient;
using System.Data;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        // Updated connection string with your server name
        private string connectionString = "Server=CELESTIAL-WANNA\\PHYNANN;Database=LibraryDB;Integrated Security=True;TrustServerCertificate=True;";

        public MainForm()
        {
            InitializeComponent();
            // Wire up all events in the constructor for reliability
            this.Load += new System.EventHandler(this.MainForm_Load);

            // Book tab buttons
            btnAddBook.Click += btnAddBook_Click;
            btnEditBook.Click += btnEditBook_Click;
            btnDeleteBook.Click += btnDeleteBook_Click;

            // Borrower tab buttons
            btnAddBorrower.Click += btnAddBorrower_Click;
            btnEditBorrower.Click += btnEditBorrower_Click;

            // Loan tab buttons
            btnIssueBook.Click += btnIssueBook_Click;
            btnReturnBook.Click += btnReturnBook_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load all data when the form starts
            RefreshAllData();
        }

        // --- Data Loading & Refreshing ---

        private void RefreshAllData()
        {
            // This single method will be called to refresh all grids
            LoadBooks();
            LoadBorrowers();
            LoadLoans();
        }

        public void LoadBooks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookID, ISBN, Title, Author, IsAvailable FROM Books";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load books data. Error: " + ex.Message);
            }
        }

        public void LoadBorrowers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BorrowerID, FirstName, LastName, Email, RegistrationDate FROM Borrowers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvBorrowers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load borrowers data. Error: " + ex.Message);
            }
        }

        public void LoadLoans()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            L.LoanID,
                            B.Title AS BookTitle,
                            BR.FirstName + ' ' + BR.LastName AS BorrowerName,
                            L.DateIssued,
                            L.DateDue,
                            L.DateReturned
                        FROM Loans AS L
                        JOIN Books AS B ON L.BookID = B.BookID
                        JOIN Borrowers AS BR ON L.BorrowerID = BR.BorrowerID
                        ORDER BY L.DateIssued DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLoans.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load loans data. Error: " + ex.Message);
            }
        }

        // --- Book Button Events ---
        private void btnAddBook_Click(object sender, EventArgs e) { using (var form = new BookDetailsForm()) { if (form.ShowDialog() == DialogResult.OK) RefreshAllData(); } }
        private void btnEditBook_Click(object sender, EventArgs e) { if (dgvBooks.SelectedRows.Count > 0) { int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value); using (var form = new BookDetailsForm(id)) { if (form.ShowDialog() == DialogResult.OK) RefreshAllData(); } } else { MessageBox.Show("Please select a book to edit."); } }
        private void btnDeleteBook_Click(object sender, EventArgs e) { /* ... same as before, but calls RefreshAllData() ... */ }

        // --- Borrower Button Events ---
        private void btnAddBorrower_Click(object sender, EventArgs e) { using (var form = new BorrowerDetailsForm()) { if (form.ShowDialog() == DialogResult.OK) RefreshAllData(); } }
        private void btnEditBorrower_Click(object sender, EventArgs e) { if (dgvBorrowers.SelectedRows.Count > 0) { int id = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value); using (var form = new BorrowerDetailsForm(id)) { if (form.ShowDialog() == DialogResult.OK) RefreshAllData(); } } else { MessageBox.Show("Please select a borrower to edit."); } }

        // --- Loan Button Events ---

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            using (IssueBookForm issueForm = new IssueBookForm())
            {
                if (issueForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh everything because a book's availability has changed
                    RefreshAllData();
                }
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a loan to return.");
                return;
            }

            // Check if the book has already been returned
            if (dgvLoans.SelectedRows[0].Cells["DateReturned"].Value != DBNull.Value)
            {
                MessageBox.Show("This book has already been returned.");
                return;
            }

            int loanId = Convert.ToInt32(dgvLoans.SelectedRows[0].Cells["LoanID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // First, get the BookID from the loan record
                    int bookId;
                    string getBookIdQuery = "SELECT BookID FROM Loans WHERE LoanID = @LoanID";
                    SqlCommand getBookIdCmd = new SqlCommand(getBookIdQuery, conn, transaction);
                    getBookIdCmd.Parameters.AddWithValue("@LoanID", loanId);
                    bookId = (int)getBookIdCmd.ExecuteScalar();

                    // 1. Update the loan record with the return date
                    string updateLoanQuery = "UPDATE Loans SET DateReturned = @DateReturned WHERE LoanID = @LoanID";
                    SqlCommand updateLoanCmd = new SqlCommand(updateLoanQuery, conn, transaction);
                    updateLoanCmd.Parameters.AddWithValue("@DateReturned", DateTime.Now);
                    updateLoanCmd.Parameters.AddWithValue("@LoanID", loanId);
                    updateLoanCmd.ExecuteNonQuery();

                    // 2. Update the book's availability
                    string updateBookQuery = "UPDATE Books SET IsAvailable = 1 WHERE BookID = @BookID";
                    SqlCommand updateBookCmd = new SqlCommand(updateBookQuery, conn, transaction);
                    updateBookCmd.Parameters.AddWithValue("@BookID", bookId);
                    updateBookCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Book returned successfully!");
                    RefreshAllData();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Failed to return book. Error: " + ex.Message);
                }
            }
        }
    }
}
