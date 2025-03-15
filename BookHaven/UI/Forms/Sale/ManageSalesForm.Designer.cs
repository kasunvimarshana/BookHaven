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
            splitContainer1 = new SplitContainer();
            cmbCustomerId = new ComboBox();
            btnSalesDetails = new Button();
            lblCustomeId = new Label();
            btnReset = new Button();
            btnAddSale = new Button();
            btnDeleteOrder = new Button();
            btnDeleteSale = new Button();
            dgvSales = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(cmbCustomerId);
            splitContainer1.Panel1.Controls.Add(btnSalesDetails);
            splitContainer1.Panel1.Controls.Add(lblCustomeId);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(btnAddSale);
            splitContainer1.Panel1.Controls.Add(btnDeleteOrder);
            splitContainer1.Panel1.Controls.Add(btnDeleteSale);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvSales);
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // cmbCustomerId
            // 
            cmbCustomerId.FormattingEnabled = true;
            cmbCustomerId.Location = new Point(226, 6);
            cmbCustomerId.Name = "cmbCustomerId";
            cmbCustomerId.Size = new Size(350, 33);
            cmbCustomerId.TabIndex = 17;
            // 
            // btnSalesDetails
            // 
            btnSalesDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalesDetails.Location = new Point(1054, 176);
            btnSalesDetails.Name = "btnSalesDetails";
            btnSalesDetails.Size = new Size(115, 35);
            btnSalesDetails.TabIndex = 23;
            btnSalesDetails.Text = "Details";
            btnSalesDetails.UseVisualStyleBackColor = true;
            btnSalesDetails.Click += btnSalesDetails_Click;
            // 
            // lblCustomeId
            // 
            lblCustomeId.AutoSize = true;
            lblCustomeId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomeId.Location = new Point(12, 9);
            lblCustomeId.Name = "lblCustomeId";
            lblCustomeId.Size = new Size(93, 25);
            lblCustomeId.TabIndex = 18;
            lblCustomeId.Text = "Customer";
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 22;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnAddSale
            // 
            btnAddSale.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddSale.Location = new Point(1054, 12);
            btnAddSale.Name = "btnAddSale";
            btnAddSale.Size = new Size(115, 35);
            btnAddSale.TabIndex = 19;
            btnAddSale.Text = "Add";
            btnAddSale.UseVisualStyleBackColor = true;
            btnAddSale.Click += btnAddSale_Click;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteOrder.Location = new Point(1054, 94);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(115, 35);
            btnDeleteOrder.TabIndex = 21;
            btnDeleteOrder.Text = "Delete";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteSale_Click;
            // 
            // btnDeleteSale
            // 
            btnDeleteSale.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteSale.Location = new Point(1054, 53);
            btnDeleteSale.Name = "btnDeleteSale";
            btnDeleteSale.Size = new Size(115, 35);
            btnDeleteSale.TabIndex = 20;
            btnDeleteSale.Text = "Update";
            btnDeleteSale.UseVisualStyleBackColor = true;
            btnDeleteSale.Click += btnUpdateSale_Click;
            // 
            // dgvSales
            // 
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(3, 3);
            dgvSales.Name = "dgvSales";
            dgvSales.RowHeadersWidth = 62;
            dgvSales.Size = new Size(1172, 434);
            dgvSales.TabIndex = 16;
            dgvSales.CellClick += dgvSales_CellClick;
            // 
            // ManageSalesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageSalesForm";
            Text = "ManageSalesForm";
            Load += ManageSalesForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ComboBox cmbCustomerId;
        private Button btnSalesDetails;
        private Label lblCustomeId;
        private Button btnReset;
        private Button btnAddSale;
        private Button btnDeleteOrder;
        private Button btnDeleteSale;
        private DataGridView dgvSales;
    }
}