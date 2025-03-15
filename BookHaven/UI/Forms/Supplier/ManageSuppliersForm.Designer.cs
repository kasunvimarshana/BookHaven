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
            splitContainer1 = new SplitContainer();
            txtName = new TextBox();
            btnReset = new Button();
            txtAddress = new TextBox();
            btnDeleteSupplier = new Button();
            lblName = new Label();
            btnUpdateSupplier = new Button();
            lblAddress = new Label();
            btnAddSupplier = new Button();
            lblContactPerson = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtContactPerson = new TextBox();
            dgvSuppliers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(txtName);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(txtAddress);
            splitContainer1.Panel1.Controls.Add(btnDeleteSupplier);
            splitContainer1.Panel1.Controls.Add(lblName);
            splitContainer1.Panel1.Controls.Add(btnUpdateSupplier);
            splitContainer1.Panel1.Controls.Add(lblAddress);
            splitContainer1.Panel1.Controls.Add(btnAddSupplier);
            splitContainer1.Panel1.Controls.Add(lblContactPerson);
            splitContainer1.Panel1.Controls.Add(lblPhone);
            splitContainer1.Panel1.Controls.Add(lblEmail);
            splitContainer1.Panel1.Controls.Add(txtEmail);
            splitContainer1.Panel1.Controls.Add(txtPhone);
            splitContainer1.Panel1.Controls.Add(txtContactPerson);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvSuppliers);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(226, 6);
            txtName.Name = "txtName";
            txtName.Size = new Size(350, 31);
            txtName.TabIndex = 33;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 132);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 40;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(226, 154);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(350, 31);
            txtAddress.TabIndex = 42;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteSupplier.Location = new Point(1054, 92);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(115, 35);
            btnDeleteSupplier.TabIndex = 39;
            btnDeleteSupplier.Text = "Delete";
            btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.Location = new Point(12, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 25);
            lblName.TabIndex = 29;
            lblName.Text = "Name";
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateSupplier.Location = new Point(1054, 52);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(115, 35);
            btnUpdateSupplier.TabIndex = 38;
            btnUpdateSupplier.Text = "Update";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddress.Location = new Point(12, 157);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(80, 25);
            lblAddress.TabIndex = 41;
            lblAddress.Text = "Address";
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddSupplier.Location = new Point(1054, 12);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(115, 35);
            btnAddSupplier.TabIndex = 37;
            btnAddSupplier.Text = "Add";
            btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // lblContactPerson
            // 
            lblContactPerson.AutoSize = true;
            lblContactPerson.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContactPerson.Location = new Point(12, 46);
            lblContactPerson.Name = "lblContactPerson";
            lblContactPerson.Size = new Size(140, 25);
            lblContactPerson.TabIndex = 30;
            lblContactPerson.Text = "Contact Person";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhone.Location = new Point(12, 83);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(66, 25);
            lblPhone.TabIndex = 31;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(12, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 32;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(226, 117);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 31);
            txtEmail.TabIndex = 34;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(226, 80);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(350, 31);
            txtPhone.TabIndex = 35;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(226, 43);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(350, 31);
            txtContactPerson.TabIndex = 36;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(3, 3);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 62;
            dgvSuppliers.Size = new Size(1172, 434);
            dgvSuppliers.TabIndex = 28;
            // 
            // ManageSuppliersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageSuppliersForm";
            Text = "ManageSuppliersForm";
            Load += ManageSuppliersForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvSuppliers;
        private TextBox txtAddress;
        private Label lblAddress;
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
    }
}