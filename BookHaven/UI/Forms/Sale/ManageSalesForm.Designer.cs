namespace BookHaven.UI.Forms.Sale
{
    partial class ManageSalesForm
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
            btnSalesDetails = new Button();
            panel1 = new Panel();
            dgvSales = new DataGridView();
            btnReset = new Button();
            btnDeleteOrder = new Button();
            btnDeleteSale = new Button();
            btnAddSale = new Button();
            lblCustomeId = new Label();
            cmbCustomerId = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // btnSalesDetails
            // 
            btnSalesDetails.Location = new Point(428, 7);
            btnSalesDetails.Name = "btnSalesDetails";
            btnSalesDetails.Size = new Size(112, 34);
            btnSalesDetails.TabIndex = 15;
            btnSalesDetails.Text = "Details";
            btnSalesDetails.UseVisualStyleBackColor = true;
            btnSalesDetails.Click += btnSalesDetails_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvSales);
            panel1.Location = new Point(12, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(1012, 412);
            panel1.TabIndex = 14;
            // 
            // dgvSales
            // 
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(3, 3);
            dgvSales.Name = "dgvSales";
            dgvSales.RowHeadersWidth = 62;
            dgvSales.Size = new Size(1006, 406);
            dgvSales.TabIndex = 0;
            dgvSales.CellClick += dgvSales_CellClick;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(900, 7);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Location = new Point(782, 7);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(112, 34);
            btnDeleteOrder.TabIndex = 12;
            btnDeleteOrder.Text = "Delete";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteSale_Click;
            // 
            // btnDeleteSale
            // 
            btnDeleteSale.Location = new Point(664, 7);
            btnDeleteSale.Name = "btnDeleteSale";
            btnDeleteSale.Size = new Size(112, 34);
            btnDeleteSale.TabIndex = 11;
            btnDeleteSale.Text = "Update";
            btnDeleteSale.UseVisualStyleBackColor = true;
            btnDeleteSale.Click += btnUpdateSale_Click;
            // 
            // btnAddSale
            // 
            btnAddSale.Location = new Point(546, 7);
            btnAddSale.Name = "btnAddSale";
            btnAddSale.Size = new Size(112, 34);
            btnAddSale.TabIndex = 10;
            btnAddSale.Text = "Add";
            btnAddSale.UseVisualStyleBackColor = true;
            btnAddSale.Click += btnAddSale_Click;
            // 
            // lblCustomeId
            // 
            lblCustomeId.AutoSize = true;
            lblCustomeId.Location = new Point(12, 12);
            lblCustomeId.Name = "lblCustomeId";
            lblCustomeId.Size = new Size(89, 25);
            lblCustomeId.TabIndex = 9;
            lblCustomeId.Text = "Customer";
            // 
            // cmbCustomerId
            // 
            cmbCustomerId.FormattingEnabled = true;
            cmbCustomerId.Location = new Point(134, 9);
            cmbCustomerId.Name = "cmbCustomerId";
            cmbCustomerId.Size = new Size(241, 33);
            cmbCustomerId.TabIndex = 8;
            // 
            // ManageSalesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 532);
            Controls.Add(btnSalesDetails);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnDeleteSale);
            Controls.Add(btnAddSale);
            Controls.Add(lblCustomeId);
            Controls.Add(cmbCustomerId);
            Name = "ManageSalesForm";
            Text = "ManageSalesForm";
            Load += ManageSalesForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalesDetails;
        private Panel panel1;
        private DataGridView dgvSales;
        private Button btnReset;
        private Button btnDeleteOrder;
        private Button btnDeleteSale;
        private Button btnAddSale;
        private Label lblCustomeId;
        private ComboBox cmbCustomerId;
    }
}