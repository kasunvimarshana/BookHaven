using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
//using iText.Layout.Properties;
//using iText.Kernel.Colors;
using BookHaven.BLL;
using BookHaven.Models;

namespace BookHaven.Reports
{
    class SalesDetailReportService
    {
        private readonly SalesService _salesService;
        private readonly CustomerService _customerService;
        private readonly BookService _bookService;

        public SalesDetailReportService()
        {
            _salesService = new SalesService();
            _customerService = new CustomerService();
            _bookService = new BookService();
        }

        public string GenerateTextReport(int saleId)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, $"SalesDetail_Report_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            var sale = _salesService.GetSaleWithSalesDetails(saleId);

            Customer customer = _customerService.GetCustomerById(sale.CustomerId) ?? new Customer { FullName = "Unknown" };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("********** SALES REPORT **********");
                writer.WriteLine($"Sale ID: {sale.Id}");
                writer.WriteLine($"Customer: {customer.FullName}");
                //writer.WriteLine($"User ID: {sale.UserId}");
                writer.WriteLine($"Total Amount: {sale.TotalAmount:C}");
                writer.WriteLine($"Discount: {sale.Discount:C}");
                writer.WriteLine($"Sale Date: {sale.SaleDate}");
                writer.WriteLine("----------------------------------");
                writer.WriteLine("Item Details:");
                writer.WriteLine("Book\tQuantity\tPrice");

                foreach (var detail in sale.SalesDetails)
                {
                    Book? book = _bookService.GetBookById(detail.BookId);
                    writer.WriteLine($"{book?.Title}\t{detail.Quantity}\t{detail.Price:C}");
                }

                writer.WriteLine("**********************************");
            }

            //Console.WriteLine("Report generated successfully.");
            return filePath;
        }
    }

}
