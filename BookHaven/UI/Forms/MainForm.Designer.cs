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
            labelEmail = new Label();
            lblRole = new Label();
            lblEmail = new Label();
            labelRole = new Label();
            labelName = new Label();
            lblName = new Label();
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            panelMonthlySales = new Panel();
            label2 = new Label();
            panelProductSales = new Panel();
            panelRevenueByGenre = new Panel();
            panelTopSellingBooks = new Panel();
            panelOrderStatus = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBookManager
            // 
            btnBookManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnCustomerManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnSupplierManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnUserManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnOrderManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnSaleManager.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point);
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
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelEmail.Location = new Point(156, 62);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(58, 28);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "-NA-";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblRole.Location = new Point(13, 117);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(54, 28);
            lblRole.TabIndex = 4;
            lblRole.Text = "Role";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmail.Location = new Point(13, 62);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(64, 28);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelRole.Location = new Point(156, 117);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(58, 28);
            labelRole.TabIndex = 2;
            labelRole.Text = "-NA-";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelName.Location = new Point(156, 10);
            labelName.Name = "labelName";
            labelName.Size = new Size(58, 28);
            labelName.TabIndex = 1;
            labelName.Text = "-NA-";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblName.Location = new Point(13, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(68, 28);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(517, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(panelMonthlySales);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(panelProductSales);
            splitContainer1.Size = new Size(696, 440);
            splitContainer1.SplitterDistance = 348;
            splitContainer1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(132, 25);
            label1.TabIndex = 1;
            label1.Text = "Monthly Sales";
            // 
            // panelMonthlySales
            // 
            panelMonthlySales.Location = new Point(3, 31);
            panelMonthlySales.Name = "panelMonthlySales";
            panelMonthlySales.Size = new Size(342, 406);
            panelMonthlySales.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 2;
            label2.Text = "Book Sales";
            // 
            // panelProductSales
            // 
            panelProductSales.Location = new Point(3, 31);
            panelProductSales.Name = "panelProductSales";
            panelProductSales.Size = new Size(338, 406);
            panelProductSales.TabIndex = 0;
            // 
            // panelRevenueByGenre
            // 
            panelRevenueByGenre.Location = new Point(12, 501);
            panelRevenueByGenre.Name = "panelRevenueByGenre";
            panelRevenueByGenre.Size = new Size(499, 356);
            panelRevenueByGenre.TabIndex = 8;
            // 
            // panelTopSellingBooks
            // 
            panelTopSellingBooks.Location = new Point(520, 501);
            panelTopSellingBooks.Name = "panelTopSellingBooks";
            panelTopSellingBooks.Size = new Size(342, 356);
            panelTopSellingBooks.TabIndex = 9;
            // 
            // panelOrderStatus
            // 
            panelOrderStatus.Location = new Point(872, 501);
            panelOrderStatus.Name = "panelOrderStatus";
            panelOrderStatus.Size = new Size(341, 356);
            panelOrderStatus.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 473);
            label3.Name = "label3";
            label3.Size = new Size(169, 25);
            label3.TabIndex = 10;
            label3.Text = "Revenue By Genre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(520, 473);
            label4.Name = "label4";
            label4.Size = new Size(162, 25);
            label4.TabIndex = 11;
            label4.Text = "Top Selling Books";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(872, 473);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 12;
            label5.Text = "Order Status";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 869);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panelOrderStatus);
            Controls.Add(panelTopSellingBooks);
            Controls.Add(panelRevenueByGenre);
            Controls.Add(splitContainer1);
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
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private SplitContainer splitContainer1;
        private Panel panelMonthlySales;
        private Panel panelProductSales;
        private Panel panelRevenueByGenre;
        private Panel panelTopSellingBooks;
        private Panel panelOrderStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}