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
using System.Diagnostics;

namespace BookHaven.UI.Forms.OrderDetail
{
    public partial class ManageOrderDetailsForm : Form
    {
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderService _orderService;
        private readonly BookService _bookService;
        private Models.OrderDetail? _selectedOrderDetail;
        private Models.Order? _selectedOrder;
        private bool _isUpdateMode = false; // Flag to track update mode
        int _orderId;

        public ManageOrderDetailsForm(int orderId)
        {
            InitializeComponent();
            _orderDetailService = new OrderDetailService();
            _orderService = new OrderService();
            _bookService = new BookService();
            InitializeLayout();
            _orderId = orderId;
        }

        private void ManageOrderDetailsForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
            LoadOrder();
            InitializeBookIdComboBox();
            ResetForm();
            // BindOrderDetailToControls();
        }

        private void InitializeLayout()
        {
            dgvOrderDetails.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void InitializeBookIdComboBox()
        {
            List<Models.Book> books = _bookService.GetAllBooks();
            cmbBookId.DataSource = books;
            cmbBookId.DisplayMember = "Title";
            cmbBookId.ValueMember = "Id";
        }

        private void ResetForm()
        {
            txtPrice.Clear();
            txtQuantity.Clear();
            cmbBookId.SelectedIndex = -1;
            _selectedOrderDetail = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddOrderDetail.Visible = !isUpdateMode;
            btnUpdateOrderDetail.Visible = isUpdateMode;
            btnDeleteOrderDetail.Visible = isUpdateMode;
        }

        private void LoadOrderDetails()
        {
            try
            {
                List<Models.OrderDetail> orderDetails = _orderDetailService.GetOrderDetailsByOrderId(_orderId);
                dgvOrderDetails.DataSource = orderDetails;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load order detais.", ex);
            }
        }

        private void LoadOrder()
        {
            try
            {
                Models.Order order = _orderService.GetOrderById(_orderId);
                _selectedOrder = order;

                ConfigureOrderView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load order.", ex);
            }
        }

        private void ConfigureOrderView()
        {
            //
        }

        private void ConfigureDataGridView()
        {
            if (dgvOrderDetails.Columns.Contains("Order"))
            {
                dgvOrderDetails.Columns["Order"].Visible = false;
            }
            if (dgvOrderDetails.Columns.Contains("BookId"))
            {
                dgvOrderDetails.Columns["BookId"].Visible = false;
            }
            if (dgvOrderDetails.Columns.Contains("Book"))
            {
                dgvOrderDetails.Columns["Book"].Visible = false;
            }
            if (!dgvOrderDetails.Columns.Contains("BookTitle"))
            {
                dgvOrderDetails.Columns.Add("BookTitle", "Book");
            }

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["BookId"].Value != null)
                {
                    int bookId = Convert.ToInt32(row.Cells["BookId"].Value);
                    Models.Book? book = _bookService.GetBookById(bookId);
                    row.Cells["BookTitle"].Value = book?.Title ?? "NA";
                }
            }

            dgvOrderDetails.ClearSelection();
        }

        private void BindOrderDetailToControls()
        {
            if (_selectedOrderDetail == null)
            {
                return;
            }

            // Data binding for the controls
            cmbBookId.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();

            cmbBookId.DataBindings.Add("SelectedValue", _selectedOrderDetail, "BookId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrice.DataBindings.Add("Text", _selectedOrderDetail, "Price");
            txtQuantity.DataBindings.Add("Text", _selectedOrderDetail, "Quantity");
        }

        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvOrderDetails.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a order detail for update
            _selectedOrderDetail = GetOrderDetailFromGrid(e.RowIndex);
            BindOrderDetailToControls();
            ToggleButtons(isUpdateMode: true);
        }

        private Models.OrderDetail GetOrderDetailFromGrid(int rowIndex)
        {
            return new Models.OrderDetail
            {
                Id = Convert.ToInt32(dgvOrderDetails.Rows[rowIndex].Cells["Id"].Value),
                OrderId = Convert.ToInt32(dgvOrderDetails.Rows[rowIndex].Cells["OrderId"].Value),
                BookId = Convert.ToInt32(dgvOrderDetails.Rows[rowIndex].Cells["BookId"].Value),
                Quantity = Convert.ToInt32(dgvOrderDetails.Rows[rowIndex].Cells["Quantity"].Value),
                Price = Convert.ToDecimal(dgvOrderDetails.Rows[rowIndex].Cells["Price"].Value)
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessOrderDetailAction(bool isUpdate)
        {
            if (!TryGetOrderDetailInput(out Models.OrderDetail orderDetail, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _orderDetailService.UpdateOrderDetail(orderDetail) : (_orderDetailService.CreateOrderDetail(orderDetail) != -1);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"OrderDetail {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadOrderDetails();
                    LoadOrder();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} order detail.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"OrderDetail {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetOrderDetailInput(out Models.OrderDetail orderDetail, out string errorMessage)
        {
            int id = _selectedOrderDetail?.Id ?? 0;
            int orderId = _selectedOrderDetail?.OrderId ?? _selectedOrder.Id;
            int bookId = Convert.ToInt32(cmbBookId.SelectedValue);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);

            orderDetail = new Models.OrderDetail
            {
                Id = id,
                OrderId = orderId,
                BookId = bookId,
                Quantity = quantity,
                Price = price
            };

            return ValidateOrderDetail(orderDetail, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateOrderDetail(Models.OrderDetail orderDetail, bool isUpdateMode, out string errorMessage)
        {
            if (orderDetail.Quantity < 0)
            {
                errorMessage = "Quantity cannot be negative.";
                return false;
            }
            if (orderDetail.Price < 0)
            {
                errorMessage = "Price cannot be negative.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {
            ProcessOrderDetailAction(isUpdate: false);
        }

        private void btnUpdateOrderDetail_Click(object sender, EventArgs e)
        {
            ProcessOrderDetailAction(isUpdate: true);
        }

        private void btnDeleteOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedOrder == null)
                {
                    MessageBox.Show("Please select a order detail to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedOrderDetail.Id}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_orderDetailService.DeleteOrderDetail(_selectedOrderDetail.Id))
                {
                    MessageBox.Show(
                        "OrderDetail deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadOrderDetails();
                    LoadOrder();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting order detail.");
                }
            }
            catch (Exception ex)
            {
                ShowError("OrderDetail deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void cmbBookId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Models.Book? book = cmbBookId.SelectedItem as Models.Book;
            txtPrice.Text = (book != null) ? book?.Price.ToString() : string.Empty;
        }
    }
}
