using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.BLL;
using BookHaven.DAL;
using BookHaven.Utilities;
using BookHaven.Enums;
using Models = BookHaven.Models;
using System.Xml.Linq;
using BookHaven.Models;

namespace BookHaven.UI.Forms.Supplier
{
    public partial class ManageSuppliersForm : Form
    {
        private readonly SupplierService _supplierService;
        private Models.Supplier? _selectedSupplier;
        private bool _isUpdateMode = false; // Flag to track update mode

        public ManageSuppliersForm()
        {
            InitializeComponent();
            _supplierService = new SupplierService();
            InitializeLayout();
        }

        private void ManageSuppliersForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            ResetForm();
            // BindSupplierToControls();
        }

        private void InitializeLayout()
        {
            dgvSuppliers.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void ResetForm()
        {
            txtName.Clear();
            txtContactPerson.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            _selectedSupplier = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddSupplier.Visible = !isUpdateMode;
            btnUpdateSupplier.Visible = isUpdateMode;
            btnDeleteSupplier.Visible = isUpdateMode;
        }

        private void LoadSuppliers()
        {
            try
            {
                List<Models.Supplier> suppliers = _supplierService.GetAllSuppliers();
                dgvSuppliers.DataSource = suppliers;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load suppliers.", ex);
            }
        }
        private void ConfigureDataGridView()
        {
            if (dgvSuppliers.Columns.Contains("CreatedAt"))
            {
                dgvSuppliers.Columns["CreatedAt"].DefaultCellStyle.Format = "d";
            }

            dgvSuppliers.ClearSelection();
        }

        private void BindSupplierToControls()
        {
            if (_selectedSupplier == null)
            {
                return;
            }

            // Data binding for the controls
            txtName.DataBindings.Clear();
            txtContactPerson.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            txtName.DataBindings.Add("Text", _selectedSupplier, "Name");
            txtContactPerson.DataBindings.Add("Text", _selectedSupplier, "ContactPerson");
            txtPhone.DataBindings.Add("Text", _selectedSupplier, "Phone");
            txtEmail.DataBindings.Add("Text", _selectedSupplier, "Email");
            txtAddress.DataBindings.Add("Text", _selectedSupplier, "Address");
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvSuppliers.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a supplier for update
            _selectedSupplier = GetSupplierFromGrid(e.RowIndex);
            BindSupplierToControls();
            ToggleButtons(isUpdateMode: true);
        }
        private Models.Supplier GetSupplierFromGrid(int rowIndex)
        {
            return new Models.Supplier
            {
                Id = Convert.ToInt32(dgvSuppliers.Rows[rowIndex].Cells["Id"].Value),
                Name = dgvSuppliers.Rows[rowIndex].Cells["Name"].Value?.ToString(),
                ContactPerson = dgvSuppliers.Rows[rowIndex].Cells["ContactPerson"].Value?.ToString(),
                Phone = dgvSuppliers.Rows[rowIndex].Cells["Phone"].Value?.ToString(),
                Email = dgvSuppliers.Rows[rowIndex].Cells["Email"].Value?.ToString(),
                Address = dgvSuppliers.Rows[rowIndex].Cells["Address"].Value?.ToString(),
                CreatedAt = Convert.ToDateTime(dgvSuppliers.Rows[rowIndex].Cells["CreatedAt"].Value)
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessSupplierAction(bool isUpdate)
        {
            if (!TryGetSupplierInput(out Models.Supplier supplier, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _supplierService.UpdateSupplier(supplier) : _supplierService.CreateSupplier(supplier);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"Supplier {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadSuppliers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} supplier.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Supplier {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetSupplierInput(out Models.Supplier supplier, out string errorMessage)
        {
            int id = _selectedSupplier?.Id ?? 0;
            string name = txtName.Text;
            string contactPerson = txtContactPerson.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            DateTime createdAt = _selectedSupplier?.CreatedAt ?? DateTime.Now;

            supplier = new Models.Supplier
            {
                Id = id,
                Name = name,
                ContactPerson = contactPerson,
                Phone = phone,
                Email = email,
                Address = address,
                CreatedAt = createdAt
            };

            return ValidateSupplier(supplier, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateSupplier(Models.Supplier supplier, bool isUpdateMode, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
            {
                errorMessage = "Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(supplier.ContactPerson))
            {
                errorMessage = "ContactPerson is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(supplier.Phone))
            {
                errorMessage = "Phone is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(supplier.Email))
            {
                errorMessage = "Email is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(supplier.Address))
            {
                errorMessage = "Address is required.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            ProcessSupplierAction(isUpdate: false);
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            ProcessSupplierAction(isUpdate: true);
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedSupplier == null)
                {
                    MessageBox.Show("Please select a supplier to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedSupplier.Name}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_supplierService.DeleteSupplier(_selectedSupplier.Id))
                {
                    MessageBox.Show(
                        "Supplier deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadSuppliers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting supplier.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Supplier deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
