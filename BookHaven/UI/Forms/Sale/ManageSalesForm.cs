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
using BookHaven.Helpers;

namespace BookHaven.UI.Forms.Sale
{
    public partial class ManageSalesForm : Form
    {
        private readonly SalesService _salesService;
        private readonly CustomerService _customerService;
        private Models.Sale? _selectedSale;
        private bool _isUpdateMode = false; // Flag to track update mode

        public ManageSalesForm()
        {
            InitializeComponent();
            _salesService = new SalesService();
            _customerService = new CustomerService();
            InitializeLayout();
        }

        private void ManageSalesForm_Load(object sender, EventArgs e)
        {
            LoadSales();
            InitializeCustomerIdComboBox();
            ResetForm();
            // BindSaleToControls();
        }

        private void InitializeLayout()
        {
            dgvSales.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void InitializeCustomerIdComboBox()
        {
            List<Models.Customer> customers = _customerService.GetAllCustomers();
            cmbCustomerId.DataSource = customers;
            cmbCustomerId.DisplayMember = "FullName";
            cmbCustomerId.ValueMember = "Id";
        }

        private void ResetForm()
        {
            cmbCustomerId.SelectedIndex = -1;
            _selectedSale = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddSale.Visible = !isUpdateMode;
            btnDeleteSale.Visible = isUpdateMode;
            btnDeleteSale.Visible = isUpdateMode;
            btnSalesDetails.Visible = isUpdateMode;
        }

        private void LoadSales()
        {
            try
            {
                List<Models.Sale> sales = _salesService.GetAllSales();
                dgvSales.DataSource = sales;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load sales.", ex);
            }
        }
        private void ConfigureDataGridView()
        {
            if (dgvSales.Columns.Contains("SaleDate"))
            {
                dgvSales.Columns["SaleDate"].DefaultCellStyle.Format = "d";
            }
            if (dgvSales.Columns.Contains("CustomerId"))
            {
                dgvSales.Columns["CustomerId"].Visible = false;
            }
            if (dgvSales.Columns.Contains("Customer"))
            {
                dgvSales.Columns["Customer"].Visible = false;
            }
            if (dgvSales.Columns.Contains("UserId"))
            {
                dgvSales.Columns["UserId"].Visible = false;
            }
            if (dgvSales.Columns.Contains("User"))
            {
                dgvSales.Columns["User"].Visible = false;
            }
            if (!dgvSales.Columns.Contains("CustomerFullName"))
            {
                dgvSales.Columns.Add("CustomerFullName", "Customer");
            }

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.Cells["CustomerId"].Value != null)
                {
                    int customerId = Convert.ToInt32(row.Cells["CustomerId"].Value);
                    Models.Customer? customer = _customerService.GetCustomerById(customerId);
                    row.Cells["CustomerFullName"].Value = customer?.FullName ?? "NA";
                }
            }

            dgvSales.ClearSelection();
        }

        private void BindSaleToControls()
        {
            if (_selectedSale == null)
            {
                return;
            }

            // Data binding for the controls
            cmbCustomerId.DataBindings.Clear();

            cmbCustomerId.DataBindings.Add("SelectedValue", _selectedSale, "CustomerId", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvSales.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a sale for update
            _selectedSale = GetSaleFromGrid(e.RowIndex);
            BindSaleToControls();
            ToggleButtons(isUpdateMode: true);
        }
        private Models.Sale GetSaleFromGrid(int rowIndex)
        {
            return new Models.Sale
            {
                Id = Convert.ToInt32(dgvSales.Rows[rowIndex].Cells["Id"].Value),
                CustomerId = Convert.ToInt32(dgvSales.Rows[rowIndex].Cells["CustomerId"].Value),
                UserId = Convert.ToInt32(dgvSales.Rows[rowIndex].Cells["UserId"].Value),
                TotalAmount = Convert.ToDecimal(dgvSales.Rows[rowIndex].Cells["TotalAmount"].Value),
                Discount = Convert.ToDecimal(dgvSales.Rows[rowIndex].Cells["Discount"].Value),
                SaleDate = Convert.ToDateTime(dgvSales.Rows[rowIndex].Cells["SaleDate"].Value)
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessSaleAction(bool isUpdate)
        {
            if (!TryGetSaleInput(out Models.Sale sale, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _salesService.UpdateSale(sale) : (_salesService.CreateSale(sale) != -1);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"Sale {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadSales();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} sale.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Sale {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetSaleInput(out Models.Sale sale, out string errorMessage)
        {
            int id = _selectedSale?.Id ?? 0;
            int customerId = Convert.ToInt32(cmbCustomerId.SelectedValue);
            int userId = _selectedSale?.UserId ?? LoggedInUserSession.CurrentUser.Id;
            decimal totalAmount = _selectedSale?.TotalAmount ?? 0;
            decimal discount = _selectedSale?.Discount ?? 0;
            DateTime saleDate = _selectedSale?.SaleDate ?? DateTime.Now;

            sale = new Models.Sale
            {
                Id = id,
                CustomerId = customerId,
                UserId = userId,
                TotalAmount = totalAmount,
                Discount = discount,
                SaleDate = saleDate
            };

            return ValidateSale(sale, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateSale(Models.Sale sale, bool isUpdateMode, out string errorMessage)
        {
            if (sale.TotalAmount < 0)
            {
                errorMessage = "Total amount cannot be negative.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            ProcessSaleAction(isUpdate: false);
        }

        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            ProcessSaleAction(isUpdate: true);
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedSale == null)
                {
                    MessageBox.Show("Please select a sale to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedSale.Id}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_salesService.DeleteSale(_selectedSale.Id))
                {
                    MessageBox.Show(
                        "Sale deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadSales();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting sale.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Sale deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSalesDetails_Click(object sender, EventArgs e)
        {
            if (_selectedSale == null)
            {
                MessageBox.Show(
                    "Please select an sale to view details.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            SalesDetail.ManageSalesDetailsForm manageSalesDetailsForm = new SalesDetail.ManageSalesDetailsForm(_selectedSale.Id);

            // Refresh sales when sales details form is closed
            manageSalesDetailsForm.FormClosed += (s, args) => LoadSales();
            manageSalesDetailsForm.Show();
        }
    }
}
