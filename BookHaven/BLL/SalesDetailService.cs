using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class SalesDetailService
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
        private readonly SalesDetailRepository _salesDetailRepo = new SalesDetailRepository();
        private readonly SalesRepository _salesRepo = new SalesRepository();
        private readonly BookRepository _bookRepo = new BookRepository();

        public List<SalesDetail> GetAllSalesDetails() => _salesDetailRepo.GetAllSalesDetails();

        public SalesDetail? GetSalesDetailById(int id) => _salesDetailRepo.GetSalesDetailById(id);

        public int CreateSalesDetail(SalesDetail salesDetail, SqlTransaction transaction = null)
        {
            if (salesDetail == null)
            {
                throw new ArgumentNullException(nameof(salesDetail));
            }

            // Insert sale detail
            int insertedId = _salesDetailRepo.CreateSalesDetail(salesDetail, transaction);

            // Fetch related sale and book
            Sale? sale = _salesRepo.GetSaleById(salesDetail.SaleId);
            Book? book = _bookRepo.GetBookById(salesDetail.BookId);

            if (sale == null || book == null)
            {
                throw new InvalidOperationException("Sale or Book not found.");
            }

            // Recalculate sale total amount
            List<SalesDetail> salesDetails = GetSalesDetailBySaleId(salesDetail.SaleId);
            decimal totalAmount = salesDetails.Sum(sd => sd.Quantity * sd.Price);
            sale.TotalAmount = totalAmount;

            // Update book stock (decrese stock)
            book.StockQuantity -= salesDetail.Quantity;

            // Update records
            _salesRepo.UpdateSale(sale, transaction);
            _bookRepo.UpdateBook(book, transaction);

            return insertedId;
        }

        public bool UpdateSalesDetail(SalesDetail salesDetail, SqlTransaction transaction = null)
        {
            if (salesDetail == null)
            {
                throw new ArgumentNullException(nameof(salesDetail));
            }

            // Fetch existing sale detail
            SalesDetail? existingDetail = _salesDetailRepo.GetSalesDetailById(salesDetail.Id);
            if (existingDetail == null)
            {
                throw new InvalidOperationException("Sale detail not found.");
            }

            // Fetch related sale and book
            Sale? sale = _salesRepo.GetSaleById(salesDetail.SaleId);
            Book? book = _bookRepo.GetBookById(salesDetail.BookId);
            if (sale == null || book == null)
            {
                throw new InvalidOperationException("Sale or Book not found.");
            }

            // Calculate stock adjustment (increase if quantity reduced, decrease if increased)
            int stockAdjustment = existingDetail.Quantity - salesDetail.Quantity;
            book.StockQuantity += stockAdjustment;

            if (book.StockQuantity < 0)
            {
                throw new InvalidOperationException("Insufficient stock for the requested update.");
            }

            // Update sale detail
            bool isUpdated = _salesDetailRepo.UpdateSalesDetail(salesDetail, transaction);
            if (!isUpdated)
            {
                throw new InvalidOperationException("Failed to update sale detail.");
            }

            // Recalculate total amount for sale
            List<SalesDetail> salesDetails = GetSalesDetailBySaleId(salesDetail.SaleId);
            decimal totalAmount = salesDetails.Sum(sd => sd.Quantity * sd.Price);
            sale.TotalAmount = totalAmount;

            // Update book stock and sale records
            _salesRepo.UpdateSale(sale, transaction);
            _bookRepo.UpdateBook(book, transaction);

            return true;
        }

        //
        public bool DeleteSalesDetail(int id, SqlTransaction transaction = null)
        {
            // Fetch existing sale detail
            SalesDetail? salesDetail = _salesDetailRepo.GetSalesDetailById(id);
            if (salesDetail == null)
            {
                throw new InvalidOperationException("Sales detail not found.");
            }

            // Fetch related sale and book
            Sale? sale = _salesRepo.GetSaleById(salesDetail.SaleId);
            Book? book = _bookRepo.GetBookById(salesDetail.BookId);
            if (sale == null || book == null)
            {
                throw new InvalidOperationException("Sale or Book not found.");
            }

            // Restore stock quantity
            book.StockQuantity += salesDetail.Quantity;
            _bookRepo.UpdateBook(book, transaction);

            // Delete sales detail
            bool isDeleted = _salesDetailRepo.DeleteSalesDetail(id, transaction);
            if (!isDeleted)
            {
                throw new InvalidOperationException("Failed to delete sales detail.");
            }

            // Recalculate total amount for sale
            List<SalesDetail> salesDetails = _salesDetailRepo.GetSalesDetailBySaleId(salesDetail.SaleId);
            sale.TotalAmount = salesDetails.Sum(sa => sa.Quantity * sa.Price);

            // Update book stock and sale records
            _salesRepo.UpdateSale(sale, transaction);
            _bookRepo.UpdateBook(book, transaction);

            return true;
        }

        public List<SalesDetail> GetSalesDetailBySaleId(int saleId)
            => _salesDetailRepo.GetSalesDetailBySaleId(saleId);
    }
}
