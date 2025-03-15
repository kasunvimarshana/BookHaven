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
            splitContainer1 = new SplitContainer();
            dgvOrderDetails = new DataGridView();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            btnReset = new Button();
            btnDeleteOrderDetail = new Button();
            btnUpdateOrderDetail = new Button();
            btnAddOrderDetail = new Button();
            lblBookId = new Label();
            cmbBookId = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(btnAddOrderDetail);
            splitContainer1.Panel1.Controls.Add(txtQuantity);
            splitContainer1.Panel1.Controls.Add(cmbBookId);
            splitContainer1.Panel1.Controls.Add(lblQuantity);
            splitContainer1.Panel1.Controls.Add(lblBookId);
            splitContainer1.Panel1.Controls.Add(txtPrice);
            splitContainer1.Panel1.Controls.Add(btnUpdateOrderDetail);
            splitContainer1.Panel1.Controls.Add(lblPrice);
            splitContainer1.Panel1.Controls.Add(btnDeleteOrderDetail);
            splitContainer1.Panel1.Controls.Add(btnReset);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvOrderDetails);
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(3, 3);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.RowHeadersWidth = 62;
            dgvOrderDetails.Size = new Size(1172, 434);
            dgvOrderDetails.TabIndex = 19;
            dgvOrderDetails.CellClick += dgvOrderDetails_CellClick;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(226, 82);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(350, 31);
            txtQuantity.TabIndex = 29;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantity.Location = new Point(12, 85);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(87, 25);
            lblQuantity.TabIndex = 28;
            lblQuantity.Text = "Quantity";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(226, 45);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(350, 31);
            txtPrice.TabIndex = 27;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(12, 48);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 25);
            lblPrice.TabIndex = 26;
            lblPrice.Text = "Price";
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 25;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteOrderDetail
            // 
            btnDeleteOrderDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteOrderDetail.Location = new Point(1054, 94);
            btnDeleteOrderDetail.Name = "btnDeleteOrderDetail";
            btnDeleteOrderDetail.Size = new Size(115, 35);
            btnDeleteOrderDetail.TabIndex = 24;
            btnDeleteOrderDetail.Text = "Delete";
            btnDeleteOrderDetail.UseVisualStyleBackColor = true;
            btnDeleteOrderDetail.Click += btnDeleteOrderDetail_Click;
            // 
            // btnUpdateOrderDetail
            // 
            btnUpdateOrderDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateOrderDetail.Location = new Point(1054, 53);
            btnUpdateOrderDetail.Name = "btnUpdateOrderDetail";
            btnUpdateOrderDetail.Size = new Size(115, 35);
            btnUpdateOrderDetail.TabIndex = 23;
            btnUpdateOrderDetail.Text = "Update";
            btnUpdateOrderDetail.UseVisualStyleBackColor = true;
            btnUpdateOrderDetail.Click += btnUpdateOrderDetail_Click;
            // 
            // btnAddOrderDetail
            // 
            btnAddOrderDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddOrderDetail.Location = new Point(1054, 12);
            btnAddOrderDetail.Name = "btnAddOrderDetail";
            btnAddOrderDetail.Size = new Size(115, 35);
            btnAddOrderDetail.TabIndex = 22;
            btnAddOrderDetail.Text = "Add";
            btnAddOrderDetail.UseVisualStyleBackColor = true;
            btnAddOrderDetail.Click += btnAddOrderDetail_Click;
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookId.Location = new Point(12, 9);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(56, 25);
            lblBookId.TabIndex = 21;
            lblBookId.Text = "Book";
            // 
            // cmbBookId
            // 
            cmbBookId.FormattingEnabled = true;
            cmbBookId.Location = new Point(226, 6);
            cmbBookId.Name = "cmbBookId";
            cmbBookId.Size = new Size(350, 33);
            cmbBookId.TabIndex = 20;
            cmbBookId.SelectedIndexChanged += cmbBookId_SelectedIndexChanged;
            // 
            // ManageOrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageOrderDetailsForm";
            Text = "ManageOrderDetailsForm";
            Load += ManageOrderDetailsForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnOrderDetails;
        private SplitContainer splitContainer1;
        private Button btnAddOrderDetail;
        private TextBox txtQuantity;
        private ComboBox cmbBookId;
        private Label lblQuantity;
        private Label lblBookId;
        private TextBox txtPrice;
        private Button btnUpdateOrderDetail;
        private Label lblPrice;
        private Button btnDeleteOrderDetail;
        private Button btnReset;
        private DataGridView dgvOrderDetails;
    }
}