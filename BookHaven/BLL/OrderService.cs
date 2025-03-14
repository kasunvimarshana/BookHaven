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
    class OrderService
    {
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly OrderDetailRepository _orderDetailRepo = new OrderDetailRepository();

        public List<Order> GetAllOrders() => _orderRepo.GetAllOrders();

        public Order? GetOrderById(int id) => _orderRepo.GetOrderById(id);

        public int CreateOrder(Order order, SqlTransaction transaction = null)
            => _orderRepo.CreateOrder(order, transaction);

        public bool UpdateOrder(Order order, SqlTransaction transaction = null)
            => _orderRepo.UpdateOrder(order, transaction);

        public bool DeleteOrder(int id, SqlTransaction transaction = null) => _orderRepo.DeleteOrder(id, transaction);

        public Order? GetOrderWithOrderDetails(int orderId)
        {
            var order = _orderRepo.GetOrderById(orderId);
            if (order != null)
            {
                order.OrderDetails = _orderDetailRepo.GetOrderDetailsByOrderId(orderId);
            }
            return order;
        }
    }
}
