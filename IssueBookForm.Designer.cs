namespace LibraryManagementSystem
{
    partial class IssueBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cmbBooks = new ComboBox();
            label2 = new Label();
            cmbBorrowers = new ComboBox();
            dtpDueDate = new DateTimePicker();
            label3 = new Label();
            btnIssue = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 91);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 0;
            label1.Text = "Select Book";
            // 
            // cmbBooks
            // 
            cmbBooks.FormattingEnabled = true;
            cmbBooks.Location = new Point(125, 83);
            cmbBooks.Name = "cmbBooks";
            cmbBooks.Size = new Size(151, 28);
            cmbBooks.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 125);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 0;
            label2.Text = "Select Borrower";
            // 
            // cmbBorrowers
            // 
            cmbBorrowers.FormattingEnabled = true;
            cmbBorrowers.Location = new Point(125, 117);
            cmbBorrowers.Name = "cmbBorrowers";
            cmbBorrowers.Size = new Size(151, 28);
            cmbBorrowers.TabIndex = 1;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(125, 162);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(250, 27);
            dtpDueDate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 162);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 0;
            label3.Text = "Due Date";
            // 
            // btnIssue
            // 
            btnIssue.Location = new Point(157, 254);
            btnIssue.Name = "btnIssue";
            btnIssue.Size = new Size(94, 29);
            btnIssue.TabIndex = 3;
            btnIssue.Text = "Issue Book";
            btnIssue.UseVisualStyleBackColor = true;
            // 
            // IssueBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 337);
            Controls.Add(btnIssue);
            Controls.Add(dtpDueDate);
            Controls.Add(cmbBorrowers);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbBooks);
            Controls.Add(label1);
            Name = "IssueBookForm";
            Text = "IssueBookForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbBooks;
        private Label label2;
        private ComboBox cmbBorrowers;
        private DateTimePicker dtpDueDate;
        private Label label3;
        private Button btnIssue;
    }
}