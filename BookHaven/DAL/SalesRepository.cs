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
    class SalesRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public int CreateSale(Sale sale, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        INSERT INTO Sales (CustomerId, UserId, TotalAmount, Discount, SaleDate) 
                        OUTPUT INSERTED.Id
                        VALUES (@CustomerId, @UserId, @TotalAmount, @Discount, @SaleDate)";

                SqlParameter[] parameters = {
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = sale.CustomerId },
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = sale.UserId },
                    new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = sale.TotalAmount },
                    new SqlParameter("@Discount", SqlDbType.Decimal) { Value = sale.Discount },
                    new SqlParameter("@SaleDate", SqlDbType.DateTime) { Value = sale.SaleDate }
                };

                // Execute the query and return the inserted ID
                object result = _dbHelper.ExecuteScalar(query, parameters, transaction);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateSale failed: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateSale(Sale sale, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        UPDATE Sales SET CustomerId = @CustomerId, UserId = @UserId, TotalAmount = @TotalAmount, Discount = @Discount WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = sale.Id },
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = sale.CustomerId },
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = sale.UserId },
                    new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = sale.TotalAmount },
                    new SqlParameter("@Discount", SqlDbType.Decimal) { Value = sale.Discount }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray(), transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateSale failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteSale(int id, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"DELETE FROM Sales WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteSale failed: " + ex.Message);
                return false;
            }
        }

        public List<Sale> GetAllSales()
        {
            try
            {
                string query = @"
                        SELECT Id, CustomerId, UserId, TotalAmount, Discount, SaleDate FROM Sales";

                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<Sale> sales = new List<Sale>();
                foreach (DataRow row in dt.Rows)
                {
                    sales.Add(MapSale(row));
                }
                return sales;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllSales failed: " + ex.Message);
                return new List<Sale>();
            }
        }

        public Sale? GetSaleById(int id)
        {
            try
            {
                string query = @"
                        SELECT Id, CustomerId, UserId, TotalAmount, Discount, SaleDate FROM Sales WHERE Id = @Id";

                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapSale(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetSaleById failed: " + ex.Message);
                return null;
            }
        }

        private Sale MapSale(DataRow row)
        {
            return new Sale
            {
                Id = Convert.ToInt32(row["Id"]),
                CustomerId = Convert.ToInt32(row["CustomerId"]),
                UserId = Convert.ToInt32(row["UserId"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                Discount = Convert.ToDecimal(row["Discount"]),
                SaleDate = Convert.ToDateTime(row["SaleDate"])
            };
        }
    }
}
