namespace BookHaven.UI.Forms
{
    partial class MainForm
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
            btnBookManager = new Button();
            btnCustomerManager = new Button();
            btnSupplierManager = new Button();
            btnUserManager = new Button();
            btnOrderManager = new Button();
            btnSaleManager = new Button();
            SuspendLayout();
            // 
            // btnBookManager
            // 
            btnBookManager.Location = new Point(72, 54);
            btnBookManager.Name = "btnBookManager";
            btnBookManager.Size = new Size(234, 88);
            btnBookManager.TabIndex = 0;
            btnBookManager.Text = "Book Manager";
            btnBookManager.UseVisualStyleBackColor = true;
            btnBookManager.Click += btnBookManager_Click;
            // 
            // btnCustomerManager
            // 
            btnCustomerManager.Location = new Point(399, 54);
            btnCustomerManager.Name = "btnCustomerManager";
            btnCustomerManager.Size = new Size(234, 88);
            btnCustomerManager.TabIndex = 1;
            btnCustomerManager.Text = "Customer Manager";
            btnCustomerManager.UseVisualStyleBackColor = true;
            btnCustomerManager.Click += btnCustomerManager_Click;
            // 
            // btnSupplierManager
            // 
            btnSupplierManager.Location = new Point(72, 191);
            btnSupplierManager.Name = "btnSupplierManager";
            btnSupplierManager.Size = new Size(234, 88);
            btnSupplierManager.TabIndex = 2;
            btnSupplierManager.Text = "Supplier Manager";
            btnSupplierManager.UseVisualStyleBackColor = true;
            btnSupplierManager.Click += btnSupplierManager_Click;
            // 
            // btnUserManager
            // 
            btnUserManager.Location = new Point(399, 191);
            btnUserManager.Name = "btnUserManager";
            btnUserManager.Size = new Size(234, 88);
            btnUserManager.TabIndex = 3;
            btnUserManager.Text = "User Manager";
            btnUserManager.UseVisualStyleBackColor = true;
            btnUserManager.Click += btnUserManager_Click;
            // 
            // btnOrderManager
            // 
            btnOrderManager.Location = new Point(72, 342);
            btnOrderManager.Name = "btnOrderManager";
            btnOrderManager.Size = new Size(234, 88);
            btnOrderManager.TabIndex = 4;
            btnOrderManager.Text = "Order Manager";
            btnOrderManager.UseVisualStyleBackColor = true;
            btnOrderManager.Click += btnOrderManager_Click;
            // 
            // btnSaleManager
            // 
            btnSaleManager.Location = new Point(399, 342);
            btnSaleManager.Name = "btnSaleManager";
            btnSaleManager.Size = new Size(234, 88);
            btnSaleManager.TabIndex = 5;
            btnSaleManager.Text = "Sales Manager";
            btnSaleManager.UseVisualStyleBackColor = true;
            btnSaleManager.Click += btnSaleManager_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 594);
            Controls.Add(btnSaleManager);
            Controls.Add(btnOrderManager);
            Controls.Add(btnUserManager);
            Controls.Add(btnSupplierManager);
            Controls.Add(btnCustomerManager);
            Controls.Add(btnBookManager);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnBookManager;
        private Button btnCustomerManager;
        private Button btnSupplierManager;
        private Button btnUserManager;
        private Button btnOrderManager;
        private Button btnSaleManager;
    }
}