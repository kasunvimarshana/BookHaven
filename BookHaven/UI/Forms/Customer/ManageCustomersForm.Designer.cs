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
            splitContainer1 = new SplitContainer();
            dgvCustomers = new DataGridView();
            btnReset = new Button();
            btnDeleteCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnAddCustomer = new Button();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            txtFullName = new TextBox();
            lblAddress = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblFullName = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(lblFullName);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(lblEmail);
            splitContainer1.Panel1.Controls.Add(btnDeleteCustomer);
            splitContainer1.Panel1.Controls.Add(lblPhone);
            splitContainer1.Panel1.Controls.Add(btnUpdateCustomer);
            splitContainer1.Panel1.Controls.Add(lblAddress);
            splitContainer1.Panel1.Controls.Add(btnAddCustomer);
            splitContainer1.Panel1.Controls.Add(txtFullName);
            splitContainer1.Panel1.Controls.Add(txtEmail);
            splitContainer1.Panel1.Controls.Add(txtAddress);
            splitContainer1.Panel1.Controls.Add(txtPhone);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvCustomers);
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(3, 3);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 62;
            dgvCustomers.Size = new Size(1172, 434);
            dgvCustomers.TabIndex = 12;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 24;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteCustomer.Location = new Point(1054, 94);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(115, 35);
            btnDeleteCustomer.TabIndex = 23;
            btnDeleteCustomer.Text = "Delete";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateCustomer.Location = new Point(1054, 53);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(115, 35);
            btnUpdateCustomer.TabIndex = 22;
            btnUpdateCustomer.Text = "Update";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddCustomer.Location = new Point(1054, 12);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(115, 35);
            btnAddCustomer.TabIndex = 21;
            btnAddCustomer.Text = "Add";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(226, 43);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 31);
            txtEmail.TabIndex = 20;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(226, 80);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(350, 31);
            txtPhone.TabIndex = 19;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(226, 117);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(350, 31);
            txtAddress.TabIndex = 18;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(226, 6);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(350, 31);
            txtFullName.TabIndex = 17;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 120);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(77, 25);
            lblAddress.TabIndex = 16;
            lblAddress.Text = "Address";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(12, 83);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 46);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(12, 9);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 13;
            lblFullName.Text = "Full Name";
            // 
            // ManageCustomersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageCustomersForm";
            Text = "ManageCustomersForm";
            Load += ManageCustomersForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblFullName;
        private Button btnReset;
        private Label lblEmail;
        private Button btnDeleteCustomer;
        private Label lblPhone;
        private Button btnUpdateCustomer;
        private Label lblAddress;
        private Button btnAddCustomer;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private DataGridView dgvCustomers;
    }
}