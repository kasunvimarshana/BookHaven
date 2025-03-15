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
            panel1 = new Panel();
            lblName = new Label();
            labelName = new Label();
            labelRole = new Label();
            labelEmail = new Label();
            lblRole = new Label();
            lblEmail = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBookManager
            // 
            btnBookManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            btnBookManager.Location = new Point(12, 185);
            btnBookManager.Name = "btnBookManager";
            btnBookManager.Size = new Size(235, 85);
            btnBookManager.TabIndex = 0;
            btnBookManager.Text = "Book Manager";
            btnBookManager.UseVisualStyleBackColor = true;
            btnBookManager.Click += btnBookManager_Click;
            // 
            // btnCustomerManager
            // 
            btnCustomerManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            btnCustomerManager.Location = new Point(276, 185);
            btnCustomerManager.Name = "btnCustomerManager";
            btnCustomerManager.Size = new Size(235, 85);
            btnCustomerManager.TabIndex = 1;
            btnCustomerManager.Text = "Customer Manager";
            btnCustomerManager.UseVisualStyleBackColor = true;
            btnCustomerManager.Click += btnCustomerManager_Click;
            // 
            // btnSupplierManager
            // 
            btnSupplierManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            btnSupplierManager.Location = new Point(12, 276);
            btnSupplierManager.Name = "btnSupplierManager";
            btnSupplierManager.Size = new Size(235, 85);
            btnSupplierManager.TabIndex = 2;
            btnSupplierManager.Text = "Supplier Manager";
            btnSupplierManager.UseVisualStyleBackColor = true;
            btnSupplierManager.Click += btnSupplierManager_Click;
            // 
            // btnUserManager
            // 
            btnUserManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            btnUserManager.Location = new Point(276, 276);
            btnUserManager.Name = "btnUserManager";
            btnUserManager.Size = new Size(235, 85);
            btnUserManager.TabIndex = 3;
            btnUserManager.Text = "User Manager";
            btnUserManager.UseVisualStyleBackColor = true;
            btnUserManager.Click += btnUserManager_Click;
            // 
            // btnOrderManager
            // 
            btnOrderManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            btnOrderManager.Location = new Point(12, 367);
            btnOrderManager.Name = "btnOrderManager";
            btnOrderManager.Size = new Size(235, 85);
            btnOrderManager.TabIndex = 4;
            btnOrderManager.Text = "Order Manager";
            btnOrderManager.UseVisualStyleBackColor = true;
            btnOrderManager.Click += btnOrderManager_Click;
            // 
            // btnSaleManager
            // 
            btnSaleManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            btnSaleManager.Location = new Point(276, 367);
            btnSaleManager.Name = "btnSaleManager";
            btnSaleManager.Size = new Size(235, 85);
            btnSaleManager.TabIndex = 5;
            btnSaleManager.Text = "Sales Manager";
            btnSaleManager.UseVisualStyleBackColor = true;
            btnSaleManager.Click += btnSaleManager_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelEmail);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(labelRole);
            panel1.Controls.Add(labelName);
            panel1.Controls.Add(lblName);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(499, 167);
            panel1.TabIndex = 6;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(13, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(68, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelName.Location = new Point(156, 10);
            labelName.Name = "labelName";
            labelName.Size = new Size(58, 28);
            labelName.TabIndex = 1;
            labelName.Text = "-NA-";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelRole.Location = new Point(156, 117);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(58, 28);
            labelRole.TabIndex = 2;
            labelRole.Text = "-NA-";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelEmail.Location = new Point(156, 62);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(58, 28);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "-NA-";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.Location = new Point(13, 117);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(54, 28);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(13, 62);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(64, 28);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 476);
            Controls.Add(panel1);
            Controls.Add(btnSaleManager);
            Controls.Add(btnOrderManager);
            Controls.Add(btnUserManager);
            Controls.Add(btnSupplierManager);
            Controls.Add(btnCustomerManager);
            Controls.Add(btnBookManager);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnBookManager;
        private Button btnCustomerManager;
        private Button btnSupplierManager;
        private Button btnUserManager;
        private Button btnOrderManager;
        private Button btnSaleManager;
        private Panel panel1;
        private Label lblName;
        private Label labelRole;
        private Label labelName;
        private Label labelEmail;
        private Label lblRole;
        private Label lblEmail;
    }
}