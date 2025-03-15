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
            splitContainer1 = new SplitContainer();
            dgvBooks = new DataGridView();
            txtStockQuantity = new TextBox();
            lblStockQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblTitle);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(txtStockQuantity);
            splitContainer1.Panel1.Controls.Add(btnDeleteBook);
            splitContainer1.Panel1.Controls.Add(lblAuthor);
            splitContainer1.Panel1.Controls.Add(btnUpdateBook);
            splitContainer1.Panel1.Controls.Add(txtPrice);
            splitContainer1.Panel1.Controls.Add(btnAddBook);
            splitContainer1.Panel1.Controls.Add(lblStockQuantity);
            splitContainer1.Panel1.Controls.Add(lblGenre);
            splitContainer1.Panel1.Controls.Add(lblISBN);
            splitContainer1.Panel1.Controls.Add(lblPrice);
            splitContainer1.Panel1.Controls.Add(txtTitle);
            splitContainer1.Panel1.Controls.Add(txtISBN);
            splitContainer1.Panel1.Controls.Add(txtGenre);
            splitContainer1.Panel1.Controls.Add(txtAuthor);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvBooks);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // dgvBooks
            // 
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.Size = new Size(1172, 434);
            dgvBooks.TabIndex = 45;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(226, 191);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(350, 31);
            txtStockQuantity.TabIndex = 61;
            // 
            // lblStockQuantity
            // 
            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStockQuantity.Location = new Point(12, 197);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(134, 25);
            lblStockQuantity.TabIndex = 60;
            lblStockQuantity.Text = "StockQuantity";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(226, 154);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(350, 31);
            txtPrice.TabIndex = 59;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(12, 157);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 25);
            lblPrice.TabIndex = 58;
            lblPrice.Text = "Price";
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 57;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteBook.Location = new Point(1054, 94);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(115, 35);
            btnDeleteBook.TabIndex = 56;
            btnDeleteBook.Text = "Delete";
            btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateBook.Location = new Point(1054, 53);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(115, 35);
            btnUpdateBook.TabIndex = 55;
            btnUpdateBook.Text = "Update";
            btnUpdateBook.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            btnAddBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddBook.Location = new Point(1054, 12);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(115, 35);
            btnAddBook.TabIndex = 54;
            btnAddBook.Text = "Add";
            btnAddBook.UseVisualStyleBackColor = true;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(226, 43);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(350, 31);
            txtAuthor.TabIndex = 53;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(226, 80);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(350, 31);
            txtGenre.TabIndex = 52;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(226, 117);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(350, 31);
            txtISBN.TabIndex = 51;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(226, 6);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(350, 31);
            txtTitle.TabIndex = 50;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblISBN.Location = new Point(12, 120);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(54, 25);
            lblISBN.TabIndex = 49;
            lblISBN.Text = "ISBN";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGenre.Location = new Point(12, 83);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(63, 25);
            lblGenre.TabIndex = 48;
            lblGenre.Text = "Genre";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAuthor.Location = new Point(12, 46);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(72, 25);
            lblAuthor.TabIndex = 47;
            lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(50, 25);
            lblTitle.TabIndex = 46;
            lblTitle.Text = "Title";
            // 
            // ManageBooksForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageBooksForm";
            Text = "ManageBooksForm";
            Load += ManageBooksForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblStockQuantity;
        private Label lblGenre;
        private Label lblISBN;
        private Label lblPrice;
        private DataGridView dgvBooks;
        private TextBox txtStockQuantity;
        private TextBox txtPrice;
        private Button btnReset;
        private Button btnDeleteBook;
        private Button btnUpdateBook;
        private Button btnAddBook;
        private TextBox txtAuthor;
        private TextBox txtGenre;
        private TextBox txtISBN;
        private TextBox txtTitle;
    }
}