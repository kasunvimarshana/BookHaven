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
            splitContainer1 = new SplitContainer();
            cmbUserRole = new ComboBox();
            btnReset = new Button();
            btnAddUser = new Button();
            lblEmail = new Label();
            btnDeleteUser = new Button();
            lblFullName = new Label();
            btnUpdateUser = new Button();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtFullName = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvUsers = new DataGridView();
            lblUserRole = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(cmbUserRole);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(btnAddUser);
            splitContainer1.Panel1.Controls.Add(lblEmail);
            splitContainer1.Panel1.Controls.Add(btnDeleteUser);
            splitContainer1.Panel1.Controls.Add(lblFullName);
            splitContainer1.Panel1.Controls.Add(btnUpdateUser);
            splitContainer1.Panel1.Controls.Add(txtEmail);
            splitContainer1.Panel1.Controls.Add(txtUsername);
            splitContainer1.Panel1.Controls.Add(txtFullName);
            splitContainer1.Panel1.Controls.Add(txtPassword);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvUsers);
            splitContainer1.Panel2.Controls.Add(lblUserRole);
            splitContainer1.Panel2.Controls.Add(lblPassword);
            splitContainer1.Panel2.Controls.Add(lblUsername);
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // cmbUserRole
            // 
            cmbUserRole.FormattingEnabled = true;
            cmbUserRole.Location = new Point(226, 81);
            cmbUserRole.Name = "cmbUserRole";
            cmbUserRole.Size = new Size(350, 33);
            cmbUserRole.TabIndex = 25;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 39;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddUser.Location = new Point(1054, 12);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(115, 35);
            btnAddUser.TabIndex = 26;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(12, 46);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 38;
            lblEmail.Text = "Email";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteUser.Location = new Point(1054, 94);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(115, 35);
            btnDeleteUser.TabIndex = 27;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.Location = new Point(12, 9);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(97, 25);
            lblFullName.TabIndex = 37;
            lblFullName.Text = "Full Name";
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateUser.Location = new Point(1054, 53);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(115, 35);
            btnUpdateUser.TabIndex = 28;
            btnUpdateUser.Text = "Update";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(226, 43);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 31);
            txtEmail.TabIndex = 36;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(226, 123);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(350, 31);
            txtUsername.TabIndex = 29;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(226, 6);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(350, 31);
            txtFullName.TabIndex = 35;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(226, 167);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(350, 31);
            txtPassword.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 84);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 33;
            label1.Text = "User Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 31;
            label3.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 170);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 32;
            label2.Text = "Password";
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1172, 434);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Location = new Point(-102, 65);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(86, 25);
            lblUserRole.TabIndex = 24;
            lblUserRole.Text = "User Role";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(-102, 5);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 23;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(-102, -49);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 22;
            lblUsername.Text = "Username";
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageUsersForm";
            Text = "ManageUsersForm";
            Load += ManageUsersForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lblUserRole;
        private Label lblPassword;
        private Label lblUsername;
        private ComboBox cmbUserRole;
        private Button btnReset;
        private Button btnAddUser;
        private Label lblEmail;
        private Button btnDeleteUser;
        private Label lblFullName;
        private Button btnUpdateUser;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private Label label1;
        private Label label3;
        private Label label2;
        private DataGridView dgvUsers;
    }
}