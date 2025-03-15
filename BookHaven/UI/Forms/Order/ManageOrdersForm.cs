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

namespace BookHaven.UI.Forms.Order
{
    public partial class ManageOrdersForm : Form
    {
        private readonly OrderService _orderService;
        private readonly SupplierService _supplierService;
        private Models.Order? _selectedOrder;
        private bool _isUpdateMode = false; // Flag to track update mode

        public ManageOrdersForm()
        {
            InitializeComponent();
            _orderService = new OrderService();
            _supplierService = new SupplierService();
            InitializeLayout();
        }

        private void ManageOrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
            InitializeSupplierIdComboBox();
            ResetForm();
            // BindOrderToControls();
        }

        private void InitializeLayout()
        {
            dgvOrders.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void InitializeSupplierIdComboBox()
        {
            List<Models.Supplier> suppliers = _supplierService.GetAllSuppliers();
            cmbSupplierId.DataSource = suppliers;
            cmbSupplierId.DisplayMember = "Name";
            cmbSupplierId.ValueMember = "Id";
        }

        private void ResetForm()
        {
            cmbSupplierId.SelectedIndex = -1;
            _selectedOrder = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddOrder.Visible = !isUpdateMode;
            btnUpdateOrder.Visible = isUpdateMode;
            btnDeleteOrder.Visible = isUpdateMode;
            btnOrderDetails.Visible = isUpdateMode;
        }

        private void LoadOrders()
        {
            try
            {
                List<Models.Order> orders = _orderService.GetAllOrders();
                dgvOrders.DataSource = orders;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load orders.", ex);
            }
        }
        private void ConfigureDataGridView()
        {
            if (dgvOrders.Columns.Contains("OrderDate"))
            {
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "d";
            }
            if (dgvOrders.Columns.Contains("SupplierId"))
            {
                dgvOrders.Columns["SupplierId"].Visible = false;
            }
            if (dgvOrders.Columns.Contains("Supplier"))
            {
                dgvOrders.Columns["Supplier"].Visible = false;
            }
            if (!dgvOrders.Columns.Contains("SupplierName"))
            {
                dgvOrders.Columns.Add("SupplierName", "Supplier");
            }

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["SupplierId"].Value != null)
                {
                    int supplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                    Models.Supplier? supplier = _supplierService.GetSupplierById(supplierId);
                    row.Cells["SupplierName"].Value = supplier?.Name ?? "NA";
                }
            }

            dgvOrders.ClearSelection();
        }

        private void BindOrderToControls()
        {
            if (_selectedOrder == null)
            {
                return;
            }

            // Data binding for the controls
            cmbSupplierId.DataBindings.Clear();

            cmbSupplierId.DataBindings.Add("SelectedValue", _selectedOrder, "SupplierId", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvOrders.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a order for update
            _selectedOrder = GetOrderFromGrid(e.RowIndex);
            BindOrderToControls();
            ToggleButtons(isUpdateMode: true);
        }
        private Models.Order GetOrderFromGrid(int rowIndex)
        {
            return new Models.Order
            {
                Id = Convert.ToInt32(dgvOrders.Rows[rowIndex].Cells["Id"].Value),
                SupplierId = Convert.ToInt32(dgvOrders.Rows[rowIndex].Cells["SupplierId"].Value),
                OrderDate = Convert.ToDateTime(dgvOrders.Rows[rowIndex].Cells["OrderDate"].Value),
                TotalAmount = Convert.ToDecimal(dgvOrders.Rows[rowIndex].Cells["TotalAmount"].Value),
                OrderStatus = Enum.TryParse(
                        dgvOrders.Rows[rowIndex].Cells["OrderStatus"].Value?.ToString(),
                        out OrderStatus orderStatus
                    ) ? orderStatus : OrderStatus.Pending
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessOrderAction(bool isUpdate)
        {
            if (!TryGetOrderInput(out Models.Order order, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _orderService.UpdateOrder(order) : (_orderService.CreateOrder(order) != -1);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"Order {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadOrders();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} order.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Order {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetOrderInput(out Models.Order order, out string errorMessage)
        {
            int id = _selectedOrder?.Id ?? 0;
            int supplierId = Convert.ToInt32(cmbSupplierId.SelectedValue);
            DateTime orderDate = _selectedOrder?.OrderDate ?? DateTime.Now;
            decimal totalAmount = _selectedOrder?.TotalAmount ?? 0;
            OrderStatus orderStatus = _selectedOrder?.OrderStatus ?? OrderStatus.Pending;

            order = new Models.Order
            {
                Id = id,
                SupplierId = supplierId,
                OrderDate = orderDate,
                TotalAmount = totalAmount,
                OrderStatus = orderStatus
            };

            return ValidateOrder(order, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateOrder(Models.Order order, bool isUpdateMode, out string errorMessage)
        {
            if (order.TotalAmount < 0)
            {
                errorMessage = "Total amount cannot be negative.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            ProcessOrderAction(isUpdate: false);
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            ProcessOrderAction(isUpdate: true);
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedOrder == null)
                {
                    MessageBox.Show("Please select a order to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedOrder.Id}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_orderService.DeleteOrder(_selectedOrder.Id))
                {
                    MessageBox.Show(
                        "Order deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadOrders();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting order.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Order deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            if (_selectedOrder == null)
            {
                MessageBox.Show(
                    "Please select an order to view details.", 
                    "Validation Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
                return;
            }

            OrderDetail.ManageOrderDetailsForm manageOrderDetailsForm = new OrderDetail.ManageOrderDetailsForm(_selectedOrder.Id);

            // Refresh orders when order details form is closed
            manageOrderDetailsForm.FormClosed += (s, args) => LoadOrders();
            manageOrderDetailsForm.Show();
        }
    }
}
