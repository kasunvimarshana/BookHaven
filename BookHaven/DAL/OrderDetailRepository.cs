using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;
using BookHaven.Utilities;
using BookHaven.Enums;

namespace BookHaven.DAL
{
    class OrderDetailRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public int CreateOrderDetail(OrderDetail orderDetail, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        INSERT INTO OrderDetails (OrderId, BookId, Quantity, Price)
                        OUTPUT INSERTED.Id
                        VALUES (@OrderId, @BookId, @Quantity, @Price)";

                SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderDetail.OrderId },
                    new SqlParameter("@BookId", SqlDbType.Int) { Value = orderDetail.BookId },
                    new SqlParameter("@Quantity", SqlDbType.Int) { Value = orderDetail.Quantity },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = orderDetail.Price }
                };

                // Execute the query and return the inserted ID
                object result = _dbHelper.ExecuteScalar(query, parameters, transaction);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateOrderDetail failed: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        UPDATE OrderDetails SET OrderId = @OrderId, BookId = @BookId, Quantity = @Quantity, Price = @Price WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = orderDetail.Id },
                    new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderDetail.OrderId },
                    new SqlParameter("@BookId", SqlDbType.Int) { Value = orderDetail.BookId },
                    new SqlParameter("@Quantity", SqlDbType.Int) { Value = orderDetail.Quantity },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = orderDetail.Price }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray(), transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateOrderDetail failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteOrderDetail(int id, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"DELETE FROM OrderDetails WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteOrderDetail failed: " + ex.Message);
                return false;
            }
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            try
            {
                string query = @"
                        SELECT Id, OrderId, BookId, Quantity, Price, Subtotal FROM OrderDetails";

                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<OrderDetail> orderDetails = new List<OrderDetail>();
                foreach (DataRow row in dt.Rows)
                {
                    orderDetails.Add(MapOrderDetail(row));
                }
                return orderDetails;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllOrderDetails failed: " + ex.Message);
                return new List<OrderDetail>();
            }
        }

        public OrderDetail? GetOrderDetailById(int id)
        {
            try
            {
                string query = @"
                        SELECT Id, OrderId, BookId, Quantity, Price, Subtotal FROM OrderDetails WHERE Id = @Id";

                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapOrderDetail(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetOrderDetailById failed: " + ex.Message);
                return null;
            }
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            try
            {
                string query = @"
                        SELECT Id, OrderId, BookId, Quantity, Price, Subtotal FROM OrderDetails WHERE OrderId = @OrderId";
                SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderId }
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<OrderDetail> orderDetails = new List<OrderDetail>();
                foreach (DataRow row in dt.Rows)
                {
                    orderDetails.Add(MapOrderDetail(row));
                }
                return orderDetails;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetOrderDetailsByOrderId failed: " + ex.Message);
                return new List<OrderDetail>();
            }
        }

        private OrderDetail MapOrderDetail(DataRow row)
        {
            return new OrderDetail
            {
                Id = Convert.ToInt32(row["Id"]),
                OrderId = Convert.ToInt32(row["OrderId"]),
                BookId = Convert.ToInt32(row["BookId"]),
                Quantity = Convert.ToInt32(row["Quantity"]),
                Price = Convert.ToDecimal(row["Price"]),
                //Subtotal = Convert.ToDecimal(row["Subtotal"])
            };
        }
    }
}
