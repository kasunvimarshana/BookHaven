namespace BookHaven.UI.Forms.OrderDetail
{
    partial class ManageOrderDetailsForm
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
            panel1 = new Panel();
            dgvOrderDetails = new DataGridView();
            btnReset = new Button();
            btnDeleteOrderDetail = new Button();
            btnUpdateOrderDetail = new Button();
            btnAddOrderDetail = new Button();
            lblBookId = new Label();
            cmbBookId = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvOrderDetails);
            panel1.Location = new Point(12, 181);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 412);
            panel1.TabIndex = 14;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(3, 3);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.RowHeadersWidth = 62;
            dgvOrderDetails.Size = new Size(1218, 406);
            dgvOrderDetails.TabIndex = 0;
            dgvOrderDetails.CellClick += dgvOrderDetails_CellClick;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(900, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteOrderDetail
            // 
            btnDeleteOrderDetail.Location = new Point(782, 4);
            btnDeleteOrderDetail.Name = "btnDeleteOrderDetail";
            btnDeleteOrderDetail.Size = new Size(112, 34);
            btnDeleteOrderDetail.TabIndex = 12;
            btnDeleteOrderDetail.Text = "Delete";
            btnDeleteOrderDetail.UseVisualStyleBackColor = true;
            btnDeleteOrderDetail.Click += btnDeleteOrderDetail_Click;
            // 
            // btnUpdateOrderDetail
            // 
            btnUpdateOrderDetail.Location = new Point(664, 4);
            btnUpdateOrderDetail.Name = "btnUpdateOrderDetail";
            btnUpdateOrderDetail.Size = new Size(112, 34);
            btnUpdateOrderDetail.TabIndex = 11;
            btnUpdateOrderDetail.Text = "Update";
            btnUpdateOrderDetail.UseVisualStyleBackColor = true;
            btnUpdateOrderDetail.Click += btnUpdateOrderDetail_Click;
            // 
            // btnAddOrderDetail
            // 
            btnAddOrderDetail.Location = new Point(546, 4);
            btnAddOrderDetail.Name = "btnAddOrderDetail";
            btnAddOrderDetail.Size = new Size(112, 34);
            btnAddOrderDetail.TabIndex = 10;
            btnAddOrderDetail.Text = "Add";
            btnAddOrderDetail.UseVisualStyleBackColor = true;
            btnAddOrderDetail.Click += btnAddOrderDetail_Click;
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Location = new Point(12, 9);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(53, 25);
            lblBookId.TabIndex = 9;
            lblBookId.Text = "Book";
            // 
            // cmbBookId
            // 
            cmbBookId.FormattingEnabled = true;
            cmbBookId.Location = new Point(150, 6);
            cmbBookId.Name = "cmbBookId";
            cmbBookId.Size = new Size(241, 33);
            cmbBookId.TabIndex = 8;
            cmbBookId.SelectedIndexChanged += cmbBookId_SelectedIndexChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 68);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 15;
            lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(150, 65);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(241, 31);
            txtPrice.TabIndex = 16;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(12, 120);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(80, 25);
            lblQuantity.TabIndex = 17;
            lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(150, 117);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(241, 31);
            txtQuantity.TabIndex = 18;
            // 
            // ManageOrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 605);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteOrderDetail);
            Controls.Add(btnUpdateOrderDetail);
            Controls.Add(btnAddOrderDetail);
            Controls.Add(lblBookId);
            Controls.Add(cmbBookId);
            Name = "ManageOrderDetailsForm";
            Text = "ManageOrderDetailsForm";
            Load += ManageOrderDetailsForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOrderDetails;
        private Panel panel1;
        private DataGridView dgvOrderDetails;
        private Button btnReset;
        private Button btnDeleteOrderDetail;
        private Button btnUpdateOrderDetail;
        private Button btnAddOrderDetail;
        private Label lblBookId;
        private ComboBox cmbBookId;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
    }
}