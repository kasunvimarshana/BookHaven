namespace BookHaven.UI.Forms.User
{
    partial class ManageUsersForm
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
            dgvUsers = new DataGridView();
            cmbUserRole = new ComboBox();
            btnAddUser = new Button();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblUserRole = new Label();
            panel1 = new Panel();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            lblFullName = new Label();
            lblEmail = new Label();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1377, 332);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // cmbUserRole
            // 
            cmbUserRole.FormattingEnabled = true;
            cmbUserRole.Location = new Point(166, 120);
            cmbUserRole.Name = "cmbUserRole";
            cmbUserRole.Size = new Size(182, 33);
            cmbUserRole.TabIndex = 1;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(1041, 12);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(112, 34);
            btnAddUser.TabIndex = 2;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(1041, 92);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(112, 34);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(1041, 52);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(112, 34);
            btnUpdateUser.TabIndex = 4;
            btnUpdateUser.Text = "Update";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(166, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(182, 31);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(166, 60);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(182, 31);
            txtPassword.TabIndex = 6;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 63);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password";
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Location = new Point(12, 123);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(86, 25);
            lblUserRole.TabIndex = 9;
            lblUserRole.Text = "User Role";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvUsers);
            panel1.Location = new Point(12, 209);
            panel1.Name = "panel1";
            panel1.Size = new Size(1383, 338);
            panel1.TabIndex = 10;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(600, 12);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(182, 31);
            txtFullName.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(600, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(182, 31);
            txtEmail.TabIndex = 12;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(466, 15);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 25);
            lblFullName.TabIndex = 13;
            lblFullName.Text = "Full Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(466, 63);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1041, 132);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 566);
            Controls.Add(btnReset);
            Controls.Add(lblEmail);
            Controls.Add(lblFullName);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(panel1);
            Controls.Add(lblUserRole);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnAddUser);
            Controls.Add(cmbUserRole);
            Name = "ManageUsersForm";
            Text = "ManageUsersForm";
            Load += ManageUsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private ComboBox cmbUserRole;
        private Button btnAddUser;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblUserRole;
        private Panel panel1;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private Label lblFullName;
        private Label lblEmail;
        private Button btnReset;
    }
}