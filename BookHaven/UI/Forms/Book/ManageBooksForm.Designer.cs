namespace BookHaven.UI.Forms.Book
{
    partial class ManageBooksForm
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
            txtPrice = new TextBox();
            lblPrice = new Label();
            panel1 = new Panel();
            dgvBooks = new DataGridView();
            btnReset = new Button();
            btnDeleteBook = new Button();
            btnUpdateBook = new Button();
            btnAddBook = new Button();
            txtAuthor = new TextBox();
            txtGenre = new TextBox();
            txtISBN = new TextBox();
            txtTitle = new TextBox();
            lblISBN = new Label();
            lblGenre = new Label();
            lblAuthor = new Label();
            lblTitle = new Label();
            lblStockQuantity = new Label();
            txtStockQuantity = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(164, 239);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(270, 31);
            txtPrice.TabIndex = 42;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(25, 242);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 41;
            lblPrice.Text = "Price";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvBooks);
            panel1.Location = new Point(9, 337);
            panel1.Name = "panel1";
            panel1.Size = new Size(1164, 384);
            panel1.TabIndex = 40;
            // 
            // dgvBooks
            // 
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.Size = new Size(1158, 378);
            dgvBooks.TabIndex = 0;
            dgvBooks.CellClick += dgvBooks_CellClick;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1023, 168);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 39;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(1023, 128);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(112, 34);
            btnDeleteBook.TabIndex = 38;
            btnDeleteBook.Text = "Delete";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Location = new Point(1023, 88);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(112, 34);
            btnUpdateBook.TabIndex = 37;
            btnUpdateBook.Text = "Update";
            btnUpdateBook.UseVisualStyleBackColor = true;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(1023, 48);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(112, 34);
            btnAddBook.TabIndex = 36;
            btnAddBook.Text = "Add";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(164, 85);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(270, 31);
            txtAuthor.TabIndex = 35;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(164, 134);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(270, 31);
            txtGenre.TabIndex = 34;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(164, 190);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(270, 31);
            txtISBN.TabIndex = 33;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(164, 42);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(270, 31);
            txtTitle.TabIndex = 32;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(25, 193);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(50, 25);
            lblISBN.TabIndex = 31;
            lblISBN.Text = "ISBN";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(25, 137);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(58, 25);
            lblGenre.TabIndex = 30;
            lblGenre.Text = "Genre";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(25, 88);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(67, 25);
            lblAuthor.TabIndex = 29;
            lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(25, 45);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(44, 25);
            lblTitle.TabIndex = 28;
            lblTitle.Text = "Title";
            // 
            // lblStockQuantity
            // 
            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Location = new Point(26, 291);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(123, 25);
            lblStockQuantity.TabIndex = 43;
            lblStockQuantity.Text = "StockQuantity";
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(164, 285);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(270, 31);
            txtStockQuantity.TabIndex = 44;
            // 
            // ManageBooksForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 733);
            Controls.Add(txtStockQuantity);
            Controls.Add(lblStockQuantity);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnUpdateBook);
            Controls.Add(btnAddBook);
            Controls.Add(txtAuthor);
            Controls.Add(txtGenre);
            Controls.Add(txtISBN);
            Controls.Add(txtTitle);
            Controls.Add(lblISBN);
            Controls.Add(lblGenre);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Name = "ManageBooksForm";
            Text = "ManageBooksForm";
            Load += ManageBooksForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrice;
        private Label lblPrice;
        private Panel panel1;
        private DataGridView dgvBooks;
        private Button btnReset;
        private Button btnDeleteBook;
        private Button btnUpdateBook;
        private Button btnAddBook;
        private TextBox txtAuthor;
        private TextBox txtGenre;
        private TextBox txtISBN;
        private TextBox txtTitle;
        private Label lblISBN;
        private Label lblGenre;
        private Label lblAuthor;
        private Label lblTitle;
        private Label lblStockQuantity;
        private TextBox txtStockQuantity;
    }
}