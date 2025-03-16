using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.UI.Forms;
using Models = BookHaven.Models;
using BookHaven.Helpers;
using BookHaven.Enums;
using BookHaven.BLL;
using LiveChartsCore; // Add LiveChartsCore namespace
using LiveChartsCore.SkiaSharpView; // Add SkiaSharpView namespace
using LiveChartsCore.SkiaSharpView.WinForms; // Add WinForms namespace
using LiveChartsCore.SkiaSharpView.Painting; // Add Painting namespace
using SkiaSharp; // Add SkiaSharp namespace

namespace BookHaven.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SalesService _salesService;
        private readonly SalesDetailService _salesDetailService;
        private readonly OrderService _orderService;
        private readonly BookService _bookService;
        Models.User? _currentUser;

        private CartesianChart monthlySalesChart; // Chart for monthly sales
        private CartesianChart productSalesChart; // Chart for product sales
        private PieChart revenueByGenreChart; // Chart for revenue by genre
        private CartesianChart topSellingBooksChart; // Chart for top-selling books
        private PieChart orderStatusChart; // Chart for order status distribution

        public MainForm()
        {
            InitializeComponent();
            _salesService = new SalesService();
            _salesDetailService = new SalesDetailService();
            _orderService = new OrderService();
            _bookService = new BookService();

            // Initialize LiveChartsCore charts
            monthlySalesChart = new CartesianChart { Dock = DockStyle.Fill };
            productSalesChart = new CartesianChart { Dock = DockStyle.Fill };
            revenueByGenreChart = new PieChart { Dock = DockStyle.Fill };
            topSellingBooksChart = new CartesianChart { Dock = DockStyle.Fill };
            orderStatusChart = new PieChart { Dock = DockStyle.Fill };

            // Add charts to the form
            panelMonthlySales.Controls.Add(monthlySalesChart);
            panelProductSales.Controls.Add(productSalesChart);
            panelRevenueByGenre.Controls.Add(revenueByGenreChart);
            panelTopSellingBooks.Controls.Add(topSellingBooksChart);
            panelOrderStatus.Controls.Add(orderStatusChart);

            // Load dashboard data
            LoadDashboardData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //
            _currentUser = LoggedInUserSession.CurrentUser;
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            labelName.Text = _currentUser?.FullName ?? "-NA-";
            labelEmail.Text = _currentUser?.Email ?? "-NA-";
            labelRole.Text = _currentUser?.Role.ToString() ?? "-NA-";

            btnBookManager.Visible = LoggedInUserSession.HasRole(UserRole.Admin);
            btnCustomerManager.Visible = LoggedInUserSession.HasRole(UserRole.Admin) || LoggedInUserSession.HasRole(UserRole.SalesClerk);
            btnSupplierManager.Visible = LoggedInUserSession.HasRole(UserRole.Admin);
            btnUserManager.Visible = LoggedInUserSession.HasRole(UserRole.Admin);
            btnOrderManager.Visible = LoggedInUserSession.HasRole(UserRole.Admin);
            btnSaleManager.Visible = LoggedInUserSession.HasRole(UserRole.Admin) || LoggedInUserSession.HasRole(UserRole.SalesClerk);
        }

        private List<decimal> GetMonthlySales(List<Models.Sale> sales)
        {
            var monthlySales = new List<decimal>();
            var months = Enum.GetValues(typeof(Month)).Cast<Month>(); // Using the Month enum to loop through months

            // Initialize the monthly sales list with 0s for each month
            foreach (var month in months)
            {
                decimal monthlyTotal = 0;
                foreach (var sale in sales)
                {
                    if (sale.SaleDate.Month == (int)month) // Checking if the sale's month matches the current month
                    {
                        monthlyTotal += sale.TotalAmount;
                    }
                }
                monthlySales.Add(monthlyTotal); // Add the total sales for this month to the list
            }

            return monthlySales;
        }

        private Dictionary<string, int> GetProductSales(List<Models.Sale> sales)
        {
            var productSales = new Dictionary<string, int>();

            foreach (var sale in sales)
            {
                sale.SalesDetails = _salesDetailService.GetSalesDetailBySaleId(sale.Id);
                foreach (var detail in sale.SalesDetails)
                {
                    Models.Book? book = _bookService.GetBookById(detail.BookId);
                    if (book != null)
                    {
                        if (!productSales.ContainsKey(book.Title))
                        {
                            productSales[book.Title] = 0;
                        }
                        productSales[book.Title] += detail.Quantity;
                    }
                }
            }

            return productSales;
        }

        private Dictionary<string, decimal> GetRevenueByGenre(List<Models.Sale> sales)
        {
            var revenueByGenre = sales
                .SelectMany(s => s.SalesDetails)
                .GroupBy(d => _bookService.GetBookById(d.BookId)?.Genre)
                .ToDictionary(g => g.Key, g => g.Sum(d => d.Price * d.Quantity));

            return revenueByGenre;
        }

        private Dictionary<string, int> GetTopSellingBooks(List<Models.Sale> sales)
        {
            var topSellingBooks = sales
                .SelectMany(s => s.SalesDetails)
                .GroupBy(d => _bookService.GetBookById(d.BookId)?.Title)
                .ToDictionary(g => g.Key, g => g.Sum(d => d.Quantity))
                .OrderByDescending(kvp => kvp.Value)
                .Take(10) // Top 10 books
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return topSellingBooks;
        }

        private Dictionary<string, int> GetOrderStatusDistribution(List<Models.Order> orders)
        {
            var orderStatusDistribution = orders
                .GroupBy(o => o.OrderStatus.ToString())
                .ToDictionary(g => g.Key, g => g.Count());

            return orderStatusDistribution;
        }

        //
        private void LoadDashboardData()
        {
            try
            {
                // Fetching data
                var sales = _salesService.GetAllSales();
                var orders = _orderService.GetAllOrders();

                // Aggregating data
                var monthlySales = GetMonthlySales(sales);
                var productSales = GetProductSales(sales);
                var revenueByGenre = GetRevenueByGenre(sales);
                var topSellingBooks = GetTopSellingBooks(sales);
                var orderStatusDistribution = GetOrderStatusDistribution(orders);

                /////
                //// Line Chart for Monthly Sales
                //monthlySalesChart.Series = new ISeries[]
                //{
                //    new LineSeries<decimal>
                //    {
                //        Values = monthlySales,
                //        Name = "Monthly Sales",
                //        Stroke = new SolidColorPaint(SKColors.Blue, 2), // Customize line color and thickness
                //        Fill = null // No fill under the line
                //    }
                //};

                //// Bar Chart for Product-wise Sales
                //productSalesChart.Series = new ISeries[]
                //{
                //    new ColumnSeries<int>
                //    {
                //        Values = productSales.Values,
                //        Name = "Product Sales",
                //        Fill = new SolidColorPaint(SKColors.Green) // Customize bar color
                //    }
                //};

                //// Set X-axis labels for product sales chart
                //productSalesChart.XAxes = new List<Axis>
                //{
                //    new Axis
                //    {
                //        Labels = productSales.Keys.ToList(),
                //        Name = "Products"
                //    }
                //};
                /////
                // Line Chart for Monthly Sales
                monthlySalesChart.Series = new ISeries[]
                {
                    new LineSeries<decimal>
                    {
                        Values = monthlySales,
                        Name = "Monthly Sales",
                        Stroke = new SolidColorPaint(SKColors.Blue, 2), // Customize line color and thickness
                        Fill = null // No fill under the line
                    }
                };

                // Bar Chart for Product-wise Sales
                productSalesChart.Series = new ISeries[]
                {
                    new ColumnSeries<int>
                    {
                        Values = productSales.Values,
                        Name = "Product Sales",
                        Fill = new SolidColorPaint(SKColors.Green) // Customize bar color
                    }
                };

                // Pie Chart for Revenue by Genre
                revenueByGenreChart.Series = revenueByGenre
                    .Select(kvp => new PieSeries<decimal>
                    {
                        Values = new List<decimal> { kvp.Value },
                        Name = kvp.Key,
                        //DataLabels = true
                    })
                    .Cast<ISeries>()
                    .ToList();

                // Bar Chart for Top-Selling Books
                topSellingBooksChart.Series = new ISeries[]
                {
                    new ColumnSeries<int>
                    {
                        Values = topSellingBooks.Values,
                        Name = "Top-Selling Books",
                        Fill = new SolidColorPaint(SKColors.Orange)
                    }
                };

                topSellingBooksChart.XAxes = new List<Axis>
                {
                    new Axis { Labels = topSellingBooks.Keys.ToList(), Name = "Books" }
                };

                // Pie Chart for Order Status Distribution
                orderStatusChart.Series = orderStatusDistribution
                    .Select(kvp => new PieSeries<int>
                    {
                        Values = new List<int> { kvp.Value },
                        Name = kvp.Key,
                        //DataLabels = true
                    })
                    .Cast<ISeries>()
                    .ToList();


                // Update total sales label
                //totalSalesLabel.Text = $"Total Sales: {sales.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading dashboard data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        //

        private void btnBookManager_Click(object sender, EventArgs e)
        {
            Book.ManageBooksForm manageBooksForm = new Book.ManageBooksForm();
            manageBooksForm.Show();
        }

        private void btnCustomerManager_Click(object sender, EventArgs e)
        {
            Customer.ManageCustomersForm manageCustomersForm = new Customer.ManageCustomersForm();
            manageCustomersForm.Show();
        }

        private void btnSupplierManager_Click(object sender, EventArgs e)
        {
            Supplier.ManageSuppliersForm manageSuppliersForm = new Supplier.ManageSuppliersForm();
            manageSuppliersForm.Show();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            User.ManageUsersForm manageUsersForm = new User.ManageUsersForm();
            manageUsersForm.Show();
        }

        private void btnOrderManager_Click(object sender, EventArgs e)
        {
            Order.ManageOrdersForm manageOrdersForm = new Order.ManageOrdersForm();
            manageOrdersForm.Show();
        }

        private void btnSaleManager_Click(object sender, EventArgs e)
        {
            Sale.ManageSalesForm manageSalesForm = new Sale.ManageSalesForm();
            manageSalesForm.Show();
        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }
    }
}

