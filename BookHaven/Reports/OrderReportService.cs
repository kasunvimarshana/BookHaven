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
    class OrderReportService
    {
        private readonly OrderService _orderService;
        private readonly SupplierService _supplierService;

        public OrderReportService()
        {
            _orderService = new OrderService();
            _supplierService = new SupplierService();
        }

        //public string GeneratePdfReport()
        //{
        //    try
        //    {
        //        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //        string filePath = Path.Combine(folderPath, $"Order_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

        //        using (var writer = new PdfWriter(filePath))
        //        {
        //            using (var pdf = new PdfDocument(writer))
        //            {
        //                Document document = new Document(pdf);
        //                document.SetMargins(20, 20, 20, 20);

        //                // Title
        //                Paragraph title = new Paragraph("BookHaven - Order Report")
        //                    .SetTextAlignment(TextAlignment.CENTER)
        //                    .SetFontSize(18)
        //                    .SetBold();
        //                document.Add(title);

        //                // Date
        //                document.Add(new Paragraph($"Generated On: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
        //                    .SetTextAlignment(TextAlignment.RIGHT));

        //                // Line separator
        //                document.Add(new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine()).SetMarginBottom(10));

        //                // Fetch order details
        //                List<Order> orders = _orderService.GetAllOrders();

        //                if (!orders.Any())
        //                {
        //                    document.Add(new Paragraph("No orders found."));
        //                }
        //                else
        //                {
        //                    Table table = new Table(5).UseAllAvailableWidth();
        //                    table.AddHeaderCell(new Cell().Add(new Paragraph("ID").SetBold()).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
        //                    table.AddHeaderCell(new Cell().Add(new Paragraph("Supplier")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
        //                    table.AddHeaderCell(new Cell().Add(new Paragraph("Order Date")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
        //                    table.AddHeaderCell(new Cell().Add(new Paragraph("Total Amount")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
        //                    table.AddHeaderCell(new Cell().Add(new Paragraph("Status")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));

        //                    foreach (var order in orders)
        //                    {
        //                        Supplier supplier = _supplierService.GetSupplierById(order.SupplierId) ?? new Supplier { Name = "Unknown" };

        //                        table.AddCell(order.Id.ToString());
        //                        table.AddCell(supplier.Name);
        //                        table.AddCell(order.OrderDate.ToString("yyyy-MM-dd"));
        //                        table.AddCell($"${order.TotalAmount:F2}");
        //                        table.AddCell(order.OrderStatus.ToString());
        //                    }

        //                    document.Add(table);
        //                }

        //                document.Close();
        //            }
        //        }

        //        return filePath;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error generating report: " + ex.Message);
        //    }
        //}

        public string GenerateTextReport()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"Order_Report_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("BookHaven - Order Report");
                    writer.WriteLine($"Generated On: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine("-----------------------------------------------------------");

                    List<Order> orders = _orderService.GetAllOrders();

                    if (orders.Count == 0)
                    {
                        writer.WriteLine("No orders found.");
                    }
                    else
                    {
                        writer.WriteLine($"{"ID",-5} {"Supplier",-20} {"Order Date",-15} {"Total Amount",-10} {"Status",-10}");
                        writer.WriteLine("-----------------------------------------------------------");

                        foreach (var order in orders)
                        {
                            Supplier supplier = _supplierService.GetSupplierById(order.SupplierId) ?? new Supplier { Name = "Unknown" };

                            writer.WriteLine($"{order.Id,-5} {supplier.Name,-20} {order.OrderDate:yyyy-MM-dd,-15} {order.TotalAmount,10:F2} {order.OrderStatus,-10}");
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

        public string GenerateCsvReport()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"Order_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Order ID,Supplier,Order Date,Total Amount,Status");

                    List<Order> orders = _orderService.GetAllOrders();
                    foreach (var order in orders)
                    {
                        Supplier supplier = _supplierService.GetSupplierById(order.SupplierId) ?? new Supplier { Name = "Unknown" };

                        writer.WriteLine($"{order.Id},{supplier.Name},{order.OrderDate:yyyy-MM-dd},{order.TotalAmount:F2},{order.OrderStatus}");
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating report: " + ex.Message);
            }
        }


        public string GenerateHtmlReport()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"Order_Report_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("<html><head><title>Order Report</title></head><body>");
                    writer.WriteLine("<h2>BookHaven - Order Report</h2>");
                    writer.WriteLine($"<p>Generated On: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
                    writer.WriteLine("<table border='1'><tr><th>ID</th><th>Supplier</th><th>Order Date</th><th>Total Amount</th><th>Status</th></tr>");

                    List<Order> orders = _orderService.GetAllOrders();
                    foreach (var order in orders)
                    {
                        Supplier supplier = _supplierService.GetSupplierById(order.SupplierId) ?? new Supplier { Name = "Unknown" };

                        writer.WriteLine($"<tr><td>{order.Id}</td><td>{supplier.Name}</td><td>{order.OrderDate:yyyy-MM-dd}</td><td>${order.TotalAmount:F2}</td><td>{order.OrderStatus}</td></tr>");
                    }

                    writer.WriteLine("</table></body></html>");
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating report: " + ex.Message);
            }
        }

        public string GenerateExcelReport()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"Order_Report_{DateTime.Now:yyyyMMdd_HHmmss}.xls");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Order ID\tSupplier\tOrder Date\tTotal Amount\tStatus");

                    List<Order> orders = _orderService.GetAllOrders();
                    foreach (var order in orders)
                    {
                        Supplier supplier = _supplierService.GetSupplierById(order.SupplierId) ?? new Supplier { Name = "Unknown" };

                        writer.WriteLine($"{order.Id}\t{supplier.Name}\t{order.OrderDate:yyyy-MM-dd}\t{order.TotalAmount:F2}\t{order.OrderStatus}");
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating report: " + ex.Message);
            }
        }

    }
}
