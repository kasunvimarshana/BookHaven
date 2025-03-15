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

namespace BookHaven.UI.Forms.SalesDetail
{
    public partial class ManageSalesDetailsForm : Form
    {
        private readonly SalesDetailService _salesDetailService;
        private readonly SalesService _salesService;
        private readonly BookService _bookService;
        private Models.SalesDetail? _selectedSalesDetail;
        private Models.Sale? _selectedSale;
        private bool _isUpdateMode = false; // Flag to track update mode
        int _saleId;

        public ManageSalesDetailsForm(int saleId)
        {
            InitializeComponent();
            _salesDetailService = new SalesDetailService();
            _salesService = new SalesService();
            _bookService = new BookService();
            InitializeLayout();
            _saleId = saleId;
        }

        private void ManageSalesDetailsForm_Load(object sender, EventArgs e)
        {
            LoadSalesDetails();
            LoadSale();
            InitializeBookIdComboBox();
            ResetForm();
            // BindSalesDetailToControls();
        }

        //
        private void InitializeLayout()
        {
            dgvSalesDetails.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
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
            _selectedSalesDetail = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddSalesDetail.Visible = !isUpdateMode;
            btnUpdateSalesDetail.Visible = isUpdateMode;
            btnDeleteSalesDetail.Visible = isUpdateMode;
        }

        private void LoadSalesDetails()
        {
            try
            {
                List<Models.SalesDetail> salesDetails = _salesDetailService.GetSalesDetailBySaleId(_saleId);
                dgvSalesDetails.DataSource = salesDetails;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load sales detais.", ex);
            }
        }

        private void LoadSale()
        {
            try
            {
                Models.Sale? sale = _salesService.GetSaleById(_saleId);
                _selectedSale = sale;

                ConfigureSaleView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load sale.", ex);
            }
        }

        private void ConfigureSaleView()
        {
            //
        }

        private void ConfigureDataGridView()
        {
            if (dgvSalesDetails.Columns.Contains("Sale"))
            {
                dgvSalesDetails.Columns["Sale"].Visible = false;
            }
            if (dgvSalesDetails.Columns.Contains("BookId"))
            {
                dgvSalesDetails.Columns["BookId"].Visible = false;
            }
            if (dgvSalesDetails.Columns.Contains("Book"))
            {
                dgvSalesDetails.Columns["Book"].Visible = false;
            }
            if (!dgvSalesDetails.Columns.Contains("BookTitle"))
            {
                dgvSalesDetails.Columns.Add("BookTitle", "Book");
            }

            foreach (DataGridViewRow row in dgvSalesDetails.Rows)
            {
                if (row.Cells["BookId"].Value != null)
                {
                    int bookId = Convert.ToInt32(row.Cells["BookId"].Value);
                    Models.Book? book = _bookService.GetBookById(bookId);
                    row.Cells["BookTitle"].Value = book?.Title ?? "NA";
                }
            }

            dgvSalesDetails.ClearSelection();
        }

        private void BindSalesDetailToControls()
        {
            if (_selectedSalesDetail == null)
            {
                return;
            }

            // Data binding for the controls
            cmbBookId.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();

            cmbBookId.DataBindings.Add("SelectedValue", _selectedSalesDetail, "BookId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrice.DataBindings.Add("Text", _selectedSalesDetail, "Price");
            txtQuantity.DataBindings.Add("Text", _selectedSalesDetail, "Quantity");
        }

        private void dgvSalesDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvSalesDetails.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a sales detail for update
            _selectedSalesDetail = GetSalesDetailFromGrid(e.RowIndex);
            BindSalesDetailToControls();
            ToggleButtons(isUpdateMode: true);
        }

        private Models.SalesDetail GetSalesDetailFromGrid(int rowIndex)
        {
            return new Models.SalesDetail
            {
                Id = Convert.ToInt32(dgvSalesDetails.Rows[rowIndex].Cells["Id"].Value),
                SaleId = Convert.ToInt32(dgvSalesDetails.Rows[rowIndex].Cells["SaleId"].Value),
                BookId = Convert.ToInt32(dgvSalesDetails.Rows[rowIndex].Cells["BookId"].Value),
                Quantity = Convert.ToInt32(dgvSalesDetails.Rows[rowIndex].Cells["Quantity"].Value),
                Price = Convert.ToDecimal(dgvSalesDetails.Rows[rowIndex].Cells["Price"].Value)
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessSalesDetailAction(bool isUpdate)
        {
            if (!TryGetSalesDetailInput(out Models.SalesDetail salesDetail, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _salesDetailService.UpdateSalesDetail(salesDetail) : (_salesDetailService.CreateSalesDetail(salesDetail) != -1);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"SalesDetail {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadSalesDetails();
                    LoadSale();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} sales detail.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"SalesDetail {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetSalesDetailInput(out Models.SalesDetail salesDetail, out string errorMessage)
        {
            int id = _selectedSalesDetail?.Id ?? 0;
            int saleId = _selectedSale?.Id ?? 0;
            int bookId = Convert.ToInt32(cmbBookId.SelectedValue);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);

            salesDetail = new Models.SalesDetail
            {
                Id = id,
                SaleId = saleId,
                BookId = bookId,
                Quantity = quantity,
                Price = price
            };

            return ValidateSalesDetail(salesDetail, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateSalesDetail(Models.SalesDetail salesDetail, bool isUpdateMode, out string errorMessage)
        {
            if (salesDetail.Quantity < 0)
            {
                errorMessage = "Quantity cannot be negative.";
                return false;
            }
            if (salesDetail.Price < 0)
            {
                errorMessage = "Price cannot be negative.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddSalesDetail_Click(object sender, EventArgs e)
        {
            ProcessSalesDetailAction(isUpdate: false);
        }

        private void btnUpdateSalesDetail_Click(object sender, EventArgs e)
        {
            ProcessSalesDetailAction(isUpdate: true);
        }

        private void btnDeleteSalesDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedSalesDetail == null)
                {
                    MessageBox.Show("Please select a sales detail to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedSalesDetail.Id}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_salesDetailService.DeleteSalesDetail(_selectedSalesDetail.Id))
                {
                    MessageBox.Show(
                        "SalesDetail deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadSalesDetails();
                    LoadSale();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting sales detail.");
                }
            }
            catch (Exception ex)
            {
                ShowError("SalesDetail deletion failed.", ex);
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
