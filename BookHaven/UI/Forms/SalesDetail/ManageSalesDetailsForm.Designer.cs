namespace BookHaven.UI.Forms.SalesDetail
{
    partial class ManageSalesDetailsForm
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
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            panel1 = new Panel();
            dgvSalesDetails = new DataGridView();
            btnReset = new Button();
            btnDeleteSalesDetail = new Button();
            btnUpdateSalesDetail = new Button();
            btnAddSalesDetail = new Button();
            lblBookId = new Label();
            cmbBookId = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).BeginInit();
            SuspendLayout();
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(152, 118);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(241, 31);
            txtQuantity.TabIndex = 29;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(14, 121);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(80, 25);
            lblQuantity.TabIndex = 28;
            lblQuantity.Text = "Quantity";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(152, 66);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(241, 31);
            txtPrice.TabIndex = 27;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(14, 69);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 26;
            lblPrice.Text = "Price";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvSalesDetails);
            panel1.Location = new Point(14, 182);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 412);
            panel1.TabIndex = 25;
            // 
            // dgvSalesDetails
            // 
            dgvSalesDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesDetails.Location = new Point(3, 3);
            dgvSalesDetails.Name = "dgvSalesDetails";
            dgvSalesDetails.RowHeadersWidth = 62;
            dgvSalesDetails.Size = new Size(1218, 406);
            dgvSalesDetails.TabIndex = 0;
            dgvSalesDetails.CellClick += dgvSalesDetails_CellClick;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(902, 5);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 24;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteSalesDetail
            // 
            btnDeleteSalesDetail.Location = new Point(784, 5);
            btnDeleteSalesDetail.Name = "btnDeleteSalesDetail";
            btnDeleteSalesDetail.Size = new Size(112, 34);
            btnDeleteSalesDetail.TabIndex = 23;
            btnDeleteSalesDetail.Text = "Delete";
            btnDeleteSalesDetail.UseVisualStyleBackColor = true;
            btnDeleteSalesDetail.Click += btnDeleteSalesDetail_Click;
            // 
            // btnUpdateSalesDetail
            // 
            btnUpdateSalesDetail.Location = new Point(666, 5);
            btnUpdateSalesDetail.Name = "btnUpdateSalesDetail";
            btnUpdateSalesDetail.Size = new Size(112, 34);
            btnUpdateSalesDetail.TabIndex = 22;
            btnUpdateSalesDetail.Text = "Update";
            btnUpdateSalesDetail.UseVisualStyleBackColor = true;
            btnUpdateSalesDetail.Click += btnUpdateSalesDetail_Click;
            // 
            // btnAddSalesDetail
            // 
            btnAddSalesDetail.Location = new Point(548, 5);
            btnAddSalesDetail.Name = "btnAddSalesDetail";
            btnAddSalesDetail.Size = new Size(112, 34);
            btnAddSalesDetail.TabIndex = 21;
            btnAddSalesDetail.Text = "Add";
            btnAddSalesDetail.UseVisualStyleBackColor = true;
            btnAddSalesDetail.Click += btnAddSalesDetail_Click;
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Location = new Point(14, 10);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(53, 25);
            lblBookId.TabIndex = 20;
            lblBookId.Text = "Book";
            // 
            // cmbBookId
            // 
            cmbBookId.FormattingEnabled = true;
            cmbBookId.Location = new Point(152, 7);
            cmbBookId.Name = "cmbBookId";
            cmbBookId.Size = new Size(241, 33);
            cmbBookId.TabIndex = 19;
            cmbBookId.SelectedIndexChanged += cmbBookId_SelectedIndexChanged;
            // 
            // ManageSalesDetailsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 612);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteSalesDetail);
            Controls.Add(btnUpdateSalesDetail);
            Controls.Add(btnAddSalesDetail);
            Controls.Add(lblBookId);
            Controls.Add(cmbBookId);
            Name = "ManageSalesDetailsForm";
            Text = "ManageSalesDetailsForm";
            Load += ManageSalesDetailsForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuantity;
        private Label lblQuantity;
        private TextBox txtPrice;
        private Label lblPrice;
        private Panel panel1;
        private DataGridView dgvSalesDetails;
        private Button btnReset;
        private Button btnDeleteSalesDetail;
        private Button btnUpdateSalesDetail;
        private Button btnAddSalesDetail;
        private Label lblBookId;
        private ComboBox cmbBookId;
    }
}