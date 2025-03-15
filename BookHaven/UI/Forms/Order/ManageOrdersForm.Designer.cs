namespace BookHaven.UI.Forms.Order
{
    partial class ManageOrdersForm
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
            btnGenerateReport = new Button();
            btnOrderDetails = new Button();
            cmbSupplierId = new ComboBox();
            btnReset = new Button();
            lblSupplierId = new Label();
            btnDeleteOrder = new Button();
            btnAddOrder = new Button();
            btnUpdateOrder = new Button();
            dgvOrders = new DataGridView();
            btnGenerateDetailReport = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(btnGenerateDetailReport);
            splitContainer1.Panel1.Controls.Add(btnGenerateReport);
            splitContainer1.Panel1.Controls.Add(btnOrderDetails);
            splitContainer1.Panel1.Controls.Add(cmbSupplierId);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(lblSupplierId);
            splitContainer1.Panel1.Controls.Add(btnDeleteOrder);
            splitContainer1.Panel1.Controls.Add(btnAddOrder);
            splitContainer1.Panel1.Controls.Add(btnUpdateOrder);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvOrders);
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateReport.Location = new Point(933, 12);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(115, 35);
            btnGenerateReport.TabIndex = 16;
            btnGenerateReport.Text = "Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnOrderDetails
            // 
            btnOrderDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOrderDetails.Location = new Point(1054, 176);
            btnOrderDetails.Name = "btnOrderDetails";
            btnOrderDetails.Size = new Size(115, 35);
            btnOrderDetails.TabIndex = 15;
            btnOrderDetails.Text = "Details";
            btnOrderDetails.UseVisualStyleBackColor = true;
            btnOrderDetails.Click += btnOrderDetails_Click;
            // 
            // cmbSupplierId
            // 
            cmbSupplierId.FormattingEnabled = true;
            cmbSupplierId.Location = new Point(226, 6);
            cmbSupplierId.Name = "cmbSupplierId";
            cmbSupplierId.Size = new Size(350, 33);
            cmbSupplierId.TabIndex = 9;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 14;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // lblSupplierId
            // 
            lblSupplierId.AutoSize = true;
            lblSupplierId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSupplierId.Location = new Point(12, 9);
            lblSupplierId.Name = "lblSupplierId";
            lblSupplierId.Size = new Size(93, 25);
            lblSupplierId.TabIndex = 10;
            lblSupplierId.Text = "Customer";
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteOrder.Location = new Point(1054, 94);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(115, 35);
            btnDeleteOrder.TabIndex = 13;
            btnDeleteOrder.Text = "Delete";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddOrder.Location = new Point(1054, 12);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(115, 35);
            btnAddOrder.TabIndex = 11;
            btnAddOrder.Text = "Add";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // btnUpdateOrder
            // 
            btnUpdateOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateOrder.Location = new Point(1054, 53);
            btnUpdateOrder.Name = "btnUpdateOrder";
            btnUpdateOrder.Size = new Size(115, 35);
            btnUpdateOrder.TabIndex = 12;
            btnUpdateOrder.Text = "Update";
            btnUpdateOrder.UseVisualStyleBackColor = true;
            btnUpdateOrder.Click += btnUpdateOrder_Click;
            // 
            // dgvOrders
            // 
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.Size = new Size(1172, 434);
            dgvOrders.TabIndex = 8;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // btnGenerateDetailReport
            // 
            btnGenerateDetailReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateDetailReport.Location = new Point(933, 53);
            btnGenerateDetailReport.Name = "btnGenerateDetailReport";
            btnGenerateDetailReport.Size = new Size(115, 35);
            btnGenerateDetailReport.TabIndex = 17;
            btnGenerateDetailReport.Text = "Detail Report";
            btnGenerateDetailReport.UseVisualStyleBackColor = true;
            btnGenerateDetailReport.Click += btnGenerateDetailReport_Click;
            // 
            // ManageOrdersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageOrdersForm";
            Text = "ManageOrdersForm";
            Load += ManageOrdersForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnOrderDetails;
        private ComboBox cmbSupplierId;
        private Button btnReset;
        private Label lblSupplierId;
        private Button btnDeleteOrder;
        private Button btnAddOrder;
        private Button btnUpdateOrder;
        private DataGridView dgvOrders;
        private Button btnGenerateReport;
        private Button btnGenerateDetailReport;
    }
}