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
    class SalesReportService
    {
        //
        private readonly SalesService _salesService;
        private readonly CustomerService _customerService;

        public SalesReportService()
        {
            _salesService = new SalesService();
            _customerService = new CustomerService();
        }

        public string GenerateTextReport()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"Sales_Report_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("BookHaven - Sales Report");
                    writer.WriteLine($"Generated On: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine("-----------------------------------------------------------");

                    List<Sale> sales = _salesService.GetAllSales();

                    if (sales.Count == 0)
                    {
                        writer.WriteLine("No sales found.");
                    }
                    else
                    {
                        writer.WriteLine($"{"ID",-5} {"Customer",-20} {"Sale Date",-15} {"Total Amount",-10}");
                        writer.WriteLine("-----------------------------------------------------------");

                        foreach (var sale in sales)
                        {
                            Customer customer = _customerService.GetCustomerById(sale.CustomerId) ?? new Customer { FullName = "Unknown" };

                            writer.WriteLine($"{sale.Id,-5} {customer.FullName,-20} {sale.SaleDate:yyyy-MM-dd,-15} {sale.TotalAmount,10:F2}");
                        }
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating report: " + ex.Message);
            }
        }
        //
    }
}
