namespace BookHaven.UI.Forms.Customer
{
    partial class ManageCustomersForm
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
            lblFullName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            txtFullName = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            btnAddCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            btnReset = new Button();
            panel1 = new Panel();
            dgvCustomers = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(12, 9);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 52);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(12, 101);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 157);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(77, 25);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "Address";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(151, 6);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(270, 31);
            txtFullName.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(151, 154);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(270, 31);
            txtAddress.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(151, 98);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(270, 31);
            txtPhone.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(151, 49);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 31);
            txtEmail.TabIndex = 7;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(1010, 12);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(112, 34);
            btnAddCustomer.TabIndex = 8;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(1010, 52);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(112, 34);
            btnUpdateCustomer.TabIndex = 9;
            btnUpdateCustomer.Text = "Update";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(1010, 92);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(112, 34);
            btnDeleteCustomer.TabIndex = 10;
            btnDeleteCustomer.Text = "Delete";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1010, 132);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvCustomers);
            panel1.Location = new Point(12, 234);
            panel1.Name = "panel1";
            panel1.Size = new Size(1110, 373);
            panel1.TabIndex = 12;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(3, 3);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 62;
            dgvCustomers.Size = new Size(1104, 367);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // ManageCustomersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 619);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtFullName);
            Controls.Add(lblAddress);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblFullName);
            Name = "ManageCustomersForm";
            Text = "ManageCustomersForm";
            Load += ManageCustomersForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFullName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblAddress;
        private TextBox txtFullName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private Button btnAddCustomer;
        private Button btnUpdateCustomer;
        private Button btnDeleteCustomer;
        private Button btnReset;
        private Panel panel1;
        private DataGridView dgvCustomers;
    }
}