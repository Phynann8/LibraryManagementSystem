namespace LibraryManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnAddBook = new Button();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            dgvBooks = new DataGridView();
            tabPage2 = new TabPage();
            btnDeleteBorrower = new Button();
            btnEditBorrower = new Button();
            btnAddBorrower = new Button();
            dgvBorrowers = new DataGridView();
            tabPage3 = new TabPage();
            btnReturnBook = new Button();
            btnIssueBook = new Button();
            dgvLoans = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowers).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 525);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnAddBook);
            tabPage1.Controls.Add(btnEditBook);
            tabPage1.Controls.Add(btnDeleteBook);
            tabPage1.Controls.Add(dgvBooks);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(992, 492);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Books";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(8, 197);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(94, 29);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Add New";
            btnAddBook.UseVisualStyleBackColor = true;
            // 
            // btnEditBook
            // 
            btnEditBook.Location = new Point(178, 197);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(114, 29);
            btnEditBook.TabIndex = 2;
            btnEditBook.Text = "Edit Selected";
            btnEditBook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(417, 197);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(94, 29);
            btnDeleteBook.TabIndex = 3;
            btnDeleteBook.Text = "Delete";
            btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Dock = DockStyle.Top;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(986, 188);
            dgvBooks.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnDeleteBorrower);
            tabPage2.Controls.Add(btnEditBorrower);
            tabPage2.Controls.Add(btnAddBorrower);
            tabPage2.Controls.Add(dgvBorrowers);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(992, 492);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Borrowers";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBorrower
            // 
            btnDeleteBorrower.Location = new Point(282, 197);
            btnDeleteBorrower.Name = "btnDeleteBorrower";
            btnDeleteBorrower.Size = new Size(94, 29);
            btnDeleteBorrower.TabIndex = 3;
            btnDeleteBorrower.Text = "Delete";
            btnDeleteBorrower.UseVisualStyleBackColor = true;
            // 
            // btnEditBorrower
            // 
            btnEditBorrower.Location = new Point(126, 197);
            btnEditBorrower.Name = "btnEditBorrower";
            btnEditBorrower.Size = new Size(119, 29);
            btnEditBorrower.TabIndex = 2;
            btnEditBorrower.Text = "Edit Selected";
            btnEditBorrower.UseVisualStyleBackColor = true;
            // 
            // btnAddBorrower
            // 
            btnAddBorrower.Location = new Point(8, 197);
            btnAddBorrower.Name = "btnAddBorrower";
            btnAddBorrower.Size = new Size(94, 29);
            btnAddBorrower.TabIndex = 1;
            btnAddBorrower.Text = "Add New";
            btnAddBorrower.UseVisualStyleBackColor = true;
            // 
            // dgvBorrowers
            // 
            dgvBorrowers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBorrowers.Dock = DockStyle.Top;
            dgvBorrowers.Location = new Point(3, 3);
            dgvBorrowers.Name = "dgvBorrowers";
            dgvBorrowers.RowHeadersWidth = 51;
            dgvBorrowers.Size = new Size(986, 188);
            dgvBorrowers.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnReturnBook);
            tabPage3.Controls.Add(btnIssueBook);
            tabPage3.Controls.Add(dgvLoans);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(992, 492);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Loans";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Location = new Point(140, 197);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(127, 29);
            btnReturnBook.TabIndex = 2;
            btnReturnBook.Text = "Return";
            btnReturnBook.UseVisualStyleBackColor = true;
            // 
            // btnIssueBook
            // 
            btnIssueBook.Location = new Point(8, 197);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(94, 29);
            btnIssueBook.TabIndex = 1;
            btnIssueBook.Text = "Issus";
            btnIssueBook.UseVisualStyleBackColor = true;
            // 
            // dgvLoans
            // 
            dgvLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoans.Dock = DockStyle.Top;
            dgvLoans.Location = new Point(3, 3);
            dgvLoans.Name = "dgvLoans";
            dgvLoans.RowHeadersWidth = 51;
            dgvLoans.Size = new Size(986, 188);
            dgvLoans.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 525);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Library Management System";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBorrowers).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button btnAddBook;
        private Button btnEditBook;
        private Button btnDeleteBook;
        private DataGridView dgvBooks;
        private Button btnDeleteBorrower;
        private Button btnEditBorrower;
        private Button btnAddBorrower;
        private DataGridView dgvBorrowers;
        private Button btnReturnBook;
        private Button btnIssueBook;
        private DataGridView dgvLoans;
    }
}
