namespace BookHaven.UI.Forms.Supplier
{
    partial class ManageSuppliersForm
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
            panel1 = new Panel();
            dgvSuppliers = new DataGridView();
            btnReset = new Button();
            btnDeleteSupplier = new Button();
            btnUpdateSupplier = new Button();
            btnAddSupplier = new Button();
            txtContactPerson = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtName = new TextBox();
            lblEmail = new Label();
            lblPhone = new Label();
            lblContactPerson = new Label();
            lblName = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvSuppliers);
            panel1.Location = new Point(12, 248);
            panel1.Name = "panel1";
            panel1.Size = new Size(1142, 367);
            panel1.TabIndex = 25;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(3, 3);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 62;
            dgvSuppliers.Size = new Size(1136, 361);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1026, 140);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 24;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Location = new Point(1026, 100);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(112, 34);
            btnDeleteSupplier.TabIndex = 23;
            btnDeleteSupplier.Text = "Delete";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.Location = new Point(1026, 60);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(112, 34);
            btnUpdateSupplier.TabIndex = 22;
            btnUpdateSupplier.Text = "Update";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(1026, 20);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(112, 34);
            btnAddSupplier.TabIndex = 21;
            btnAddSupplier.Text = "Add";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(167, 57);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(270, 31);
            txtContactPerson.TabIndex = 20;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(167, 106);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(270, 31);
            txtPhone.TabIndex = 19;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(167, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 31);
            txtEmail.TabIndex = 18;
            // 
            // txtName
            // 
            txtName.Location = new Point(167, 14);
            txtName.Name = "txtName";
            txtName.Size = new Size(270, 31);
            txtName.TabIndex = 17;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(28, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 25);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(28, 109);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(62, 25);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "Phone";
            // 
            // lblContactPerson
            // 
            lblContactPerson.AutoSize = true;
            lblContactPerson.Location = new Point(28, 60);
            lblContactPerson.Name = "lblContactPerson";
            lblContactPerson.Size = new Size(131, 25);
            lblContactPerson.TabIndex = 14;
            lblContactPerson.Text = "Contact Person";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(28, 17);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 13;
            lblName.Text = "Name";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(167, 211);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(270, 31);
            txtAddress.TabIndex = 27;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(28, 214);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(77, 25);
            lblAddress.TabIndex = 26;
            lblAddress.Text = "Address";
            // 
            // ManageSuppliersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 628);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(panel1);
            Controls.Add(btnReset);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(btnAddSupplier);
            Controls.Add(txtContactPerson);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(lblEmail);
            Controls.Add(lblPhone);
            Controls.Add(lblContactPerson);
            Controls.Add(lblName);
            Name = "ManageSuppliersForm";
            Text = "ManageSuppliersForm";
            Load += ManageSuppliersForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvSuppliers;
        private Button btnReset;
        private Button btnDeleteSupplier;
        private Button btnUpdateSupplier;
        private Button btnAddSupplier;
        private TextBox txtContactPerson;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblContactPerson;
        private Label lblName;
        private TextBox txtAddress;
        private Label lblAddress;
    }
}