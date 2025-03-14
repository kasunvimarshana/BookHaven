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
    class OrderRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();
       
        public int CreateOrder(Order order, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        INSERT INTO Orders (CustomerId, TotalAmount, OrderStatus, OrderDate) 
                        OUTPUT INSERTED.Id
                        VALUES (@CustomerId, @TotalAmount, @OrderStatus, @OrderDate)";

                SqlParameter[] parameters = {
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = order.CustomerId },
                    new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = order.TotalAmount },
                    new SqlParameter("@OrderStatus", SqlDbType.NVarChar) { Value = order.OrderStatus.ToString() },
                    new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = order.OrderDate }
                };

                // Execute the query and return the inserted ID
                object result = _dbHelper.ExecuteScalar(query, parameters, transaction);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateOrder failed: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateOrder(Order order, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        UPDATE Orders SET CustomerId = @CustomerId, TotalAmount = @TotalAmount, OrderStatus = @OrderStatus WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = order.Id },
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = order.CustomerId },
                    new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = order.TotalAmount },
                    new SqlParameter("@OrderStatus", SqlDbType.NVarChar) { Value = order.OrderStatus.ToString() }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray(), transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateOrder failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteOrder(int id, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"DELETE FROM Orders WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteOrder failed: " + ex.Message);
                return false;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                string query = @"
                        SELECT o.Id as Id, o.CustomerId as CustomerId, o.TotalAmount as TotalAmount, o.OrderStatus as OrderStatus, o.OrderDate as OrderDate FROM Orders as o
                        JOIN Customers as c ON o.CustomerId = c.Id";
                
                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<Order> orders = new List<Order>();
                foreach (DataRow row in dt.Rows)
                {
                    orders.Add(MapOrder(row));
                }
                return orders;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllOrders failed: " + ex.Message);
                return new List<Order>();
            }
        }

        public Order? GetOrderById(int id)
        {
            try
            {
                string query = @"
                        SELECT o.Id as Id, o.CustomerId as CustomerId, o.TotalAmount as TotalAmount, o.OrderStatus as OrderStatus, o.OrderDate as OrderDate FROM Orders as o
                        JOIN Customers as c ON o.CustomerId = c.Id
                        WHERE o.Id = @Id";

                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapOrder(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetOrderById failed: " + ex.Message);
                return null;
            }
        }

        private Order MapOrder(DataRow row)
        {
            return new Order
            {
                Id = Convert.ToInt32(row["Id"]),
                CustomerId = Convert.ToInt32(row["CustomerId"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                OrderStatus = Enum.TryParse(
                    row["OrderStatus"].ToString(),
                    out OrderStatus orderStatus
                ) ? orderStatus : throw new Exception("Invalid OrderStatus in database"),
                OrderDate = Convert.ToDateTime(row["OrderDate"])
            };
        }
    }
}
