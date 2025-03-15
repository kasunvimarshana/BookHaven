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

namespace BookHaven.UI.Forms.Book
{
    public partial class ManageBooksForm : Form
    {
        private readonly BookService _bookService;
        private Models.Book? _selectedBook;
        private bool _isUpdateMode = false; // Flag to track update mode

        public ManageBooksForm()
        {
            InitializeComponent();
            _bookService = new BookService();
            InitializeLayout();
        }

        private void ManageBooksForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            ResetForm();
            // BindBookToControls();
        }

        //
        private void InitializeLayout()
        {
            dgvBooks.Dock = DockStyle.Fill; // Make the DataGridView fill the available space
        }

        private void ResetForm()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtISBN.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            _selectedBook = null;
            _isUpdateMode = false; // Reset update mode flag when clearing fields
            ToggleButtons(isUpdateMode: false);
        }

        private void ToggleButtons(bool isUpdateMode)
        {
            btnAddBook.Visible = !isUpdateMode;
            btnUpdateBook.Visible = isUpdateMode;
            btnDeleteBook.Visible = isUpdateMode;
        }

        private void LoadBooks()
        {
            try
            {
                List<Models.Book> books = _bookService.GetAllBooks();
                dgvBooks.DataSource = books;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                ShowError("Failed to load books.", ex);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dgvBooks.Columns.Contains("CreatedAt"))
            {
                dgvBooks.Columns["CreatedAt"].DefaultCellStyle.Format = "d";
            }
            if (dgvBooks.Columns.Contains("SupplierId"))
            {
                dgvBooks.Columns["SupplierId"].Visible = false;
            }
            if (dgvBooks.Columns.Contains("Supplier"))
            {
                dgvBooks.Columns["Supplier"].Visible = false;
            }

            dgvBooks.ClearSelection();
        }

        private void BindBookToControls()
        {
            if (_selectedBook == null)
            {
                return;
            }

            // Data binding for the controls
            txtTitle.DataBindings.Clear();
            txtAuthor.DataBindings.Clear();
            txtGenre.DataBindings.Clear();
            txtISBN.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtStockQuantity.DataBindings.Clear();

            txtTitle.DataBindings.Add("Text", _selectedBook, "Title");
            txtAuthor.DataBindings.Add("Text", _selectedBook, "Author");
            txtGenre.DataBindings.Add("Text", _selectedBook, "Genre");
            txtISBN.DataBindings.Add("Text", _selectedBook, "ISBN");
            txtPrice.DataBindings.Add("Text", _selectedBook, "Price");
            txtStockQuantity.DataBindings.Add("Text", _selectedBook, "StockQuantity");
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int count = dgvBooks.SelectedRows.Count;
            if (e.RowIndex < 0)
            {
                return;
            }

            _isUpdateMode = true; // Set update mode flag when selecting a book for update
            _selectedBook = GetBookFromGrid(e.RowIndex);
            BindBookToControls();
            ToggleButtons(isUpdateMode: true);
        }

        private Models.Book GetBookFromGrid(int rowIndex)
        {
            return new Models.Book
            {
                Id = Convert.ToInt32(dgvBooks.Rows[rowIndex].Cells["Id"].Value),
                Title = dgvBooks.Rows[rowIndex].Cells["Title"].Value?.ToString(),
                Author = dgvBooks.Rows[rowIndex].Cells["Author"].Value?.ToString(),
                Genre = dgvBooks.Rows[rowIndex].Cells["Genre"].Value?.ToString(),
                ISBN = dgvBooks.Rows[rowIndex].Cells["ISBN"].Value?.ToString(),
                Price = Convert.ToDecimal(dgvBooks.Rows[rowIndex].Cells["Price"].Value),
                StockQuantity = Convert.ToInt32(dgvBooks.Rows[rowIndex].Cells["StockQuantity"].Value),
                CreatedAt = Convert.ToDateTime(dgvBooks.Rows[rowIndex].Cells["CreatedAt"].Value)
            };
        }

        private void ShowError(string message, Exception ex)
        {
            Logger.LogError(message + " " + ex.Message);
            MessageBox.Show(message);
        }

        private void ProcessBookAction(bool isUpdate)
        {
            if (!TryGetBookInput(out Models.Book book, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                bool success = isUpdate ? _bookService.UpdateBook(book) : (_bookService.CreateBook(book) != -1);
                string action = isUpdate ? "updated" : "added";

                if (success)
                {
                    MessageBox.Show(
                        $"Book {action} successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadBooks();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Error {action} book.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Book {(isUpdate ? "update" : "add")} failed.", ex);
            }
        }

        private bool TryGetBookInput(out Models.Book book, out string errorMessage)
        {
            int id = _selectedBook?.Id ?? 0;
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string genre = txtGenre.Text;
            string isbn = txtISBN.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stockQuantity = Convert.ToInt32(txtStockQuantity.Text);
            DateTime createdAt = _selectedBook?.CreatedAt ?? DateTime.Now;

            book = new Models.Book
            {
                Id = id,
                Title = title,
                Author = author,
                Genre = genre,
                ISBN = isbn,
                Price = price,
                StockQuantity = stockQuantity,
                CreatedAt = createdAt
            };

            return ValidateBook(book, _isUpdateMode, out errorMessage);
        }

        private static bool ValidateBook(Models.Book book, bool isUpdateMode, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                errorMessage = "Title is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(book.Author))
            {
                errorMessage = "Author is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(book.ISBN))
            {
                errorMessage = "ISBN is required.";
                return false;
            }
            if (book.Price <= 0)
            {
                errorMessage = "Price must be greater than zero.";
                return false;
            }
            if (book.StockQuantity < 0)
            {
                errorMessage = "Stock quantity cannot be negative.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            ProcessBookAction(isUpdate: false);
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            ProcessBookAction(isUpdate: true);
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBook == null)
                {
                    MessageBox.Show("Please select a book to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete {_selectedBook.Title}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                if (_bookService.DeleteBook(_selectedBook.Id))
                {
                    MessageBox.Show(
                        "Book deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadBooks();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Error deleting book.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Book deletion failed.", ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        //
    }
}
