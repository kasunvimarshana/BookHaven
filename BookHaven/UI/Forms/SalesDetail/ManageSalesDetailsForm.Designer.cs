namespace BookHaven.UI.Forms.SalesDetail
{
    partial class ManageSalesDetailsForm
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
            dgvSalesDetails = new DataGridView();
            btnReset = new Button();
            btnDeleteSalesDetail = new Button();
            btnUpdateSalesDetail = new Button();
            btnAddSalesDetail = new Button();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            lblBookId = new Label();
            cmbBookId = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(txtQuantity);
            splitContainer1.Panel1.Controls.Add(btnReset);
            splitContainer1.Panel1.Controls.Add(lblQuantity);
            splitContainer1.Panel1.Controls.Add(btnDeleteSalesDetail);
            splitContainer1.Panel1.Controls.Add(txtPrice);
            splitContainer1.Panel1.Controls.Add(btnUpdateSalesDetail);
            splitContainer1.Panel1.Controls.Add(lblPrice);
            splitContainer1.Panel1.Controls.Add(btnAddSalesDetail);
            splitContainer1.Panel1.Controls.Add(lblBookId);
            splitContainer1.Panel1.Controls.Add(cmbBookId);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvSalesDetails);
            splitContainer1.Size = new Size(1178, 694);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // dgvSalesDetails
            // 
            dgvSalesDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesDetails.Location = new Point(3, 3);
            dgvSalesDetails.Name = "dgvSalesDetails";
            dgvSalesDetails.RowHeadersWidth = 62;
            dgvSalesDetails.Size = new Size(1175, 434);
            dgvSalesDetails.TabIndex = 30;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(1054, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(115, 35);
            btnReset.TabIndex = 36;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSalesDetail
            // 
            btnDeleteSalesDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteSalesDetail.Location = new Point(1054, 94);
            btnDeleteSalesDetail.Name = "btnDeleteSalesDetail";
            btnDeleteSalesDetail.Size = new Size(115, 35);
            btnDeleteSalesDetail.TabIndex = 35;
            btnDeleteSalesDetail.Text = "Delete";
            btnDeleteSalesDetail.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSalesDetail
            // 
            btnUpdateSalesDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateSalesDetail.Location = new Point(1054, 53);
            btnUpdateSalesDetail.Name = "btnUpdateSalesDetail";
            btnUpdateSalesDetail.Size = new Size(115, 35);
            btnUpdateSalesDetail.TabIndex = 34;
            btnUpdateSalesDetail.Text = "Update";
            btnUpdateSalesDetail.UseVisualStyleBackColor = true;
            // 
            // btnAddSalesDetail
            // 
            btnAddSalesDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddSalesDetail.Location = new Point(1054, 12);
            btnAddSalesDetail.Name = "btnAddSalesDetail";
            btnAddSalesDetail.Size = new Size(115, 35);
            btnAddSalesDetail.TabIndex = 33;
            btnAddSalesDetail.Text = "Add";
            btnAddSalesDetail.UseVisualStyleBackColor = true;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(226, 82);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(350, 31);
            txtQuantity.TabIndex = 46;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantity.Location = new Point(12, 85);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(87, 25);
            lblQuantity.TabIndex = 45;
            lblQuantity.Text = "Quantity";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(226, 45);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(350, 31);
            txtPrice.TabIndex = 44;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(12, 48);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 25);
            lblPrice.TabIndex = 43;
            lblPrice.Text = "Price";
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBookId.Location = new Point(12, 9);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(56, 25);
            lblBookId.TabIndex = 42;
            lblBookId.Text = "Book";
            // 
            // cmbBookId
            // 
            cmbBookId.FormattingEnabled = true;
            cmbBookId.Location = new Point(226, 6);
            cmbBookId.Name = "cmbBookId";
            cmbBookId.Size = new Size(350, 33);
            cmbBookId.TabIndex = 41;
            // 
            // ManageSalesDetailsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 694);
            Controls.Add(splitContainer1);
            Name = "ManageSalesDetailsForm";
            Text = "ManageSalesDetailsForm";
            Load += ManageSalesDetailsForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtQuantity;
        private Label lblQuantity;
        private TextBox txtPrice;
        private Label lblPrice;
        private Label lblBookId;
        private ComboBox cmbBookId;
        private DataGridView dgvSalesDetails;
        private Button btnReset;
        private Button btnDeleteSalesDetail;
        private Button btnUpdateSalesDetail;
        private Button btnAddSalesDetail;
    }
}