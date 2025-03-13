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

namespace BookHaven.UI.Forms.Customer
{
    public partial class ManageCustomersForm : Form
    {
        private readonly CustomerService _customerService;
        private Models.Customer? _selectedCustomer;
        private bool _isUpdateMode = false; // Flag to track update mode

        public ManageCustomersForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            InitializeLayout();
        }

        private void ManageCustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ResetForm();
            // BindCustomerToControls();
        }
        
        private void InitializeLayout()
        {
            dgvCustomers.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void ResetForm()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            _selectedCustomer = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddCustomer.Visible = !isUpdateMode;
            btnUpdateCustomer.Visible = isUpdateMode;
            btnDeleteCustomer.Visible = isUpdateMode;
        }

        private void LoadCustomers()
        {
            try
            {
                List<Models.Customer> customers = _customerService.GetAllCustomers();
                dgvCustomers.DataSource = customers;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load users.", ex);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvCustomers.Columns.Contains("CreatedAt"))
            {
                dgvCustomers.Columns["CreatedAt"].DefaultCellStyle.Format = "d";
            }

            dgvCustomers.ClearSelection();
        }

        private void BindCustomerToControls()
        {
            if (_selectedCustomer == null)
            {
                return;
            }
            
            // Data binding for the controls
            txtFullName.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            txtFullName.DataBindings.Add("Text", _selectedCustomer, "FullName");
            txtEmail.DataBindings.Add("Text", _selectedCustomer, "Email");
            txtPhone.DataBindings.Add("Text", _selectedCustomer, "Phone");
            txtAddress.DataBindings.Add("Text", _selectedCustomer, "Address");
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvCustomers.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a user for update
            _selectedCustomer = GetCustomerFromGrid(e.RowIndex);
            BindCustomerToControls();
            ToggleButtons(isUpdateMode: true);
        }

        private Models.Customer GetCustomerFromGrid(int rowIndex)
        {
            return new Models.Customer
            {
                Id = Convert.ToInt32(dgvCustomers.Rows[rowIndex].Cells["Id"].Value),
                FullName = dgvCustomers.Rows[rowIndex].Cells["FullName"].Value?.ToString(),
                Email = dgvCustomers.Rows[rowIndex].Cells["Email"].Value?.ToString(),
                Phone = dgvCustomers.Rows[rowIndex].Cells["Phone"].Value?.ToString(),
                Address = dgvCustomers.Rows[rowIndex].Cells["Address"].Value?.ToString(),
                CreatedAt = Convert.ToDateTime(dgvCustomers.Rows[rowIndex].Cells["CreatedAt"].Value)
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessCustomerAction(bool isUpdate)
        {
            if (!TryGetCustomerInput(out Models.Customer customer, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _customerService.UpdateCustomer(customer) : _customerService.CreateCustomer(customer);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"Customer {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadCustomers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} customer.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Customer {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetCustomerInput(out Models.Customer customer, out string errorMessage)
        {
            int id = _selectedCustomer?.Id ?? 0;
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            DateTime createdAt = _selectedCustomer?.CreatedAt ?? DateTime.Now;

            customer = new Models.Customer
            {
                Id = id,
                FullName = fullName,
                Email = email,
                Phone = phone,
                Address = address,
                CreatedAt = createdAt
            };

            return ValidateCustomer(customer, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateCustomer(Models.Customer customer, bool isUpdateMode, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                errorMessage = "FullName is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                errorMessage = "Email is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.Phone))
            {
                errorMessage = "Phone is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.Address))
            {
                errorMessage = "Address is required.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ProcessCustomerAction(isUpdate: false);
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            ProcessCustomerAction(isUpdate: true);
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCustomer == null)
                {
                    MessageBox.Show("Please select a customer to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedCustomer.FullName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_customerService.DeleteCustomer(_selectedCustomer.Id))
                {
                    MessageBox.Show(
                        "Customer deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadCustomers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting customer.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Customer deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
