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
    class OrderDetailReportService
    {
        private readonly OrderService _orderService;
        private readonly SupplierService _supplierService;

        public OrderDetailReportService()
        {
            _orderService = new OrderService();
            _supplierService = new SupplierService();
        }

        public string GenerateTextReport(int orderId)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, $"OrderDetail_Report_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            var order = _orderService.GetOrderWithOrderDetails(orderId);

            Supplier supplier = _supplierService.GetSupplierById(order.SupplierId) ?? new Supplier { Name = "Unknown" };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("********** ORDER REPORT **********");
                writer.WriteLine($"Order ID: {order.Id}");
                writer.WriteLine($"Supplier: {supplier.Name}");
                writer.WriteLine($"Total Amount: {order.TotalAmount:C}");
                writer.WriteLine($"Order Date: {order.OrderDate}");
                writer.WriteLine("----------------------------------");
                writer.WriteLine("Item Details:");
                writer.WriteLine("Book ID\tQuantity\tPrice");

                foreach (var detail in order.OrderDetails)
                {
                    writer.WriteLine($"{detail.BookId}\t{detail.Quantity}\t{detail.Price:C}");
                }

                writer.WriteLine("**********************************");
            }

            //Console.WriteLine("Report generated successfully.");
            return filePath;
        }
    }
}
