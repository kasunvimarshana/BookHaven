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
            cmbSupplierId = new ComboBox();
            lblSupplierId = new Label();
            btnAddOrder = new Button();
            btnUpdateOrder = new Button();
            btnDeleteOrder = new Button();
            btnReset = new Button();
            panel1 = new Panel();
            dgvOrders = new DataGridView();
            btnOrderDetails = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // cmbSupplierId
            // 
            cmbSupplierId.FormattingEnabled = true;
            cmbSupplierId.Location = new Point(134, 6);
            cmbSupplierId.Name = "cmbSupplierId";
            cmbSupplierId.Size = new Size(241, 33);
            cmbSupplierId.TabIndex = 0;
            // 
            // lblSupplierId
            // 
            lblSupplierId.AutoSize = true;
            lblSupplierId.Location = new Point(12, 9);
            lblSupplierId.Name = "lblSupplierId";
            lblSupplierId.Size = new Size(89, 25);
            lblSupplierId.TabIndex = 1;
            lblSupplierId.Text = "Customer";
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(546, 4);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(112, 34);
            btnAddOrder.TabIndex = 2;
            btnAddOrder.Text = "Add";
            btnAddOrder.UseVisualStyleBackColor = true;
            btnAddOrder.Click += btnAddOrder_Click;
            // 
            // btnUpdateOrder
            // 
            btnUpdateOrder.Location = new Point(664, 4);
            btnUpdateOrder.Name = "btnUpdateOrder";
            btnUpdateOrder.Size = new Size(112, 34);
            btnUpdateOrder.TabIndex = 3;
            btnUpdateOrder.Text = "Update";
            btnUpdateOrder.UseVisualStyleBackColor = true;
            btnUpdateOrder.Click += btnUpdateOrder_Click;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.Location = new Point(782, 4);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(112, 34);
            btnDeleteOrder.TabIndex = 4;
            btnDeleteOrder.Text = "Delete";
            btnDeleteOrder.UseVisualStyleBackColor = true;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(900, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 5;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvOrders);
            panel1.Location = new Point(12, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(1012, 412);
            panel1.TabIndex = 6;
            // 
            // dgvOrders
            // 
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.Size = new Size(1006, 406);
            dgvOrders.TabIndex = 0;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // btnOrderDetails
            // 
            btnOrderDetails.Location = new Point(428, 4);
            btnOrderDetails.Name = "btnOrderDetails";
            btnOrderDetails.Size = new Size(112, 34);
            btnOrderDetails.TabIndex = 7;
            btnOrderDetails.Text = "Details";
            btnOrderDetails.UseVisualStyleBackColor = true;
            btnOrderDetails.Click += btnOrderDetails_Click;
            // 
            // ManageOrdersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 511);
            Controls.Add(btnOrderDetails);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnUpdateOrder);
            Controls.Add(btnAddOrder);
            Controls.Add(lblSupplierId);
            Controls.Add(cmbSupplierId);
            Name = "ManageOrdersForm";
            Text = "ManageOrdersForm";
            Load += ManageOrdersForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSupplierId;
        private Label lblSupplierId;
        private Button btnAddOrder;
        private Button btnUpdateOrder;
        private Button btnDeleteOrder;
        private Button btnReset;
        private Panel panel1;
        private DataGridView dgvOrders;
        private Button btnOrderDetails;
    }
}