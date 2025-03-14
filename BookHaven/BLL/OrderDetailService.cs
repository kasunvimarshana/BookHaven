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
    class OrderDetailService
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
        private readonly OrderDetailRepository _orderDetailRepo = new OrderDetailRepository();
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly BookRepository _bookRepo = new BookRepository();

        public List<OrderDetail> GetAllOrderDetails() => _orderDetailRepo.GetAllOrderDetails();

        public OrderDetail? GetOrderDetailById(int id) => _orderDetailRepo.GetOrderDetailById(id);

        //public int CreateOrderDetail(OrderDetail orderDetail, SqlTransaction transaction = null)
        //{
        //    if (orderDetail == null)
        //    {
        //        throw new ArgumentNullException(nameof(orderDetail));
        //    }

        //    using (SqlConnection connection = _dbHelper.GetConnection(transaction))
        //    {
        //        connection.Open();
        //        using (SqlTransaction tran = transaction ?? connection.BeginTransaction())
        //        {
        //            try
        //            {
        //                // Insert order detail
        //                int insertedId = _orderDetailRepo.CreateOrderDetail(orderDetail, tran);

        //                // Fetch related order and book
        //                Order? order = _orderRepo.GetOrderById(orderDetail.OrderId);
        //                Book? book = _bookRepo.GetBookById(orderDetail.BookId);

        //                if (order == null || book == null)
        //                {
        //                    throw new InvalidOperationException("Order or Book not found.");
        //                }

        //                // Validate stock before updating
        //                if (book.StockQuantity < orderDetail.Quantity)
        //                {
        //                    throw new InvalidOperationException("Insufficient stock for the requested book.");
        //                }

        //                // Recalculate order total amount
        //                List<OrderDetail> orderDetails = GetOrderDetailsByOrderId(orderDetail.OrderId);
        //                decimal totalAmount = orderDetails.Sum(od => od.Quantity * od.Price);
        //                order.TotalAmount = totalAmount;

        //                // Update book stock
        //                book.StockQuantity -= orderDetail.Quantity;

        //                // Update records
        //                _orderRepo.UpdateOrder(order, tran);
        //                _bookRepo.UpdateBook(book, tran);

        //                // Commit transaction if initiated within this method
        //                if (transaction == null)
        //                {
        //                    tran?.Commit();
        //                }

        //                return insertedId;
        //            }
        //            catch
        //            {
        //                // Rollback if an error occurs
        //                if (transaction == null)
        //                {
        //                    tran.Rollback();
        //                }
        //                throw;
        //            }
        //        }
        //    }
        //}

        //public bool UpdateOrderDetail(OrderDetail orderDetail, SqlTransaction transaction = null)
        //{
        //    if (orderDetail == null)
        //    {
        //        throw new ArgumentNullException(nameof(orderDetail));
        //    }

        //    using (SqlConnection connection = _dbHelper.GetConnection(transaction))
        //    {
        //        connection.Open();
        //        using (SqlTransaction tran = transaction ?? connection.BeginTransaction())
        //        {
        //            try
        //            {
        //                // Fetch existing order detail
        //                OrderDetail? existingDetail = _orderDetailRepo.GetOrderDetailById(orderDetail.Id);
        //                if (existingDetail == null)
        //                {
        //                    throw new InvalidOperationException("Order detail not found.");
        //                }

        //                // Fetch related order and book
        //                Order? order = _orderRepo.GetOrderById(orderDetail.OrderId);
        //                Book? book = _bookRepo.GetBookById(orderDetail.BookId);
        //                if (order == null || book == null)
        //                {
        //                    throw new InvalidOperationException("Order or Book not found.");
        //                }

        //                // Adjust stock before updating order detail
        //                int stockDifference = existingDetail.Quantity - orderDetail.Quantity;
        //                if (book.StockQuantity + stockDifference < 0)
        //                {
        //                    throw new InvalidOperationException("Insufficient stock for the requested update.");
        //                }
        //                book.StockQuantity += stockDifference;

        //                // Update order detail
        //                bool isUpdated = _orderDetailRepo.UpdateOrderDetail(orderDetail, tran);
        //                if (!isUpdated)
        //                {
        //                    throw new InvalidOperationException("Failed to update order detail.");
        //                }

        //                // Recalculate total amount for order
        //                List<OrderDetail> orderDetails = GetOrderDetailsByOrderId(orderDetail.OrderId);
        //                decimal totalAmount = orderDetails.Sum(od => od.Quantity * od.Price);
        //                order.TotalAmount = totalAmount;

        //                // Update book stock and order records
        //                _orderRepo.UpdateOrder(order, tran);
        //                _bookRepo.UpdateBook(book, tran);

        //                // Commit transaction if initiated here
        //                if (transaction == null)
        //                {
        //                    tran.Commit();
        //                }

        //                return true;
        //            }
        //            catch
        //            {
        //                // Rollback on error
        //                if (transaction == null)
        //                {
        //                    tran.Rollback();
        //                }
        //                throw;
        //            }
        //        }
        //    }
        //}

        public int CreateOrderDetail(OrderDetail orderDetail, SqlTransaction transaction = null)
        {
            if (orderDetail == null)
            {
                throw new ArgumentNullException(nameof(orderDetail));
            }

            // Insert order detail
            int insertedId = _orderDetailRepo.CreateOrderDetail(orderDetail, transaction);

            // Fetch related order and book
            Order? order = _orderRepo.GetOrderById(orderDetail.OrderId);
            Book? book = _bookRepo.GetBookById(orderDetail.BookId);

            if (order == null || book == null)
            {
                throw new InvalidOperationException("Order or Book not found.");
            }

            // Validate stock before updating
            if (book.StockQuantity < orderDetail.Quantity)
            {
                throw new InvalidOperationException("Insufficient stock for the requested book.");
            }

            // Recalculate order total amount
            List<OrderDetail> orderDetails = GetOrderDetailsByOrderId(orderDetail.OrderId);
            decimal totalAmount = orderDetails.Sum(od => od.Quantity * od.Price);
            order.TotalAmount = totalAmount;

            // Update book stock
            book.StockQuantity -= orderDetail.Quantity;

            // Update records
            _orderRepo.UpdateOrder(order, transaction);
            _bookRepo.UpdateBook(book, transaction);

            return insertedId;
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail, SqlTransaction transaction = null)
        {
            if (orderDetail == null)
            {
                throw new ArgumentNullException(nameof(orderDetail));
            }

            // Fetch existing order detail
            OrderDetail? existingDetail = _orderDetailRepo.GetOrderDetailById(orderDetail.Id);
            if (existingDetail == null)
            {
                throw new InvalidOperationException("Order detail not found.");
            }

            // Fetch related order and book
            Order? order = _orderRepo.GetOrderById(orderDetail.OrderId);
            Book? book = _bookRepo.GetBookById(orderDetail.BookId);
            if (order == null || book == null)
            {
                throw new InvalidOperationException("Order or Book not found.");
            }

            // Adjust stock before updating order detail
            int stockDifference = existingDetail.Quantity - orderDetail.Quantity;
            if (book.StockQuantity + stockDifference < 0)
            {
                throw new InvalidOperationException("Insufficient stock for the requested update.");
            }
            book.StockQuantity += stockDifference;

            // Update order detail
            bool isUpdated = _orderDetailRepo.UpdateOrderDetail(orderDetail, transaction);
            if (!isUpdated)
            {
                throw new InvalidOperationException("Failed to update order detail.");
            }

            // Recalculate total amount for order
            List<OrderDetail> orderDetails = GetOrderDetailsByOrderId(orderDetail.OrderId);
            decimal totalAmount = orderDetails.Sum(od => od.Quantity * od.Price);
            order.TotalAmount = totalAmount;

            // Update book stock and order records
            _orderRepo.UpdateOrder(order, transaction);
            _bookRepo.UpdateBook(book, transaction);

            return true;
        }

        public bool DeleteOrderDetail(int id, SqlTransaction transaction = null)
            => _orderDetailRepo.DeleteOrderDetail(id, transaction);

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) 
            => _orderDetailRepo.GetOrderDetailsByOrderId(orderId);
    }
}
