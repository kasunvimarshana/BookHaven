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
    class SalesDetailRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public int CreateSalesDetail(SalesDetail salesDetail, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        INSERT INTO SalesDetails (SaleId, BookId, Quantity, Price)
                        OUTPUT INSERTED.Id
                        VALUES (@SaleId, @BookId, @Quantity, @Price)";

                SqlParameter[] parameters = {
                    new SqlParameter("@SaleId", SqlDbType.Int) { Value = salesDetail.SaleId },
                    new SqlParameter("@BookId", SqlDbType.Int) { Value = salesDetail.BookId },
                    new SqlParameter("@Quantity", SqlDbType.Int) { Value = salesDetail.Quantity },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = salesDetail.Price }
                };

                // Execute the query and return the inserted ID
                object result = _dbHelper.ExecuteScalar(query, parameters, transaction);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateSalesDetail failed: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateSalesDetail(SalesDetail salesDetail, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"
                        UPDATE SalesDetails SET SaleId = @SaleId, BookId = @BookId, Quantity = @Quantity, Price = @Price WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = salesDetail.Id },
                    new SqlParameter("@SaleId", SqlDbType.Int) { Value = salesDetail.SaleId },
                    new SqlParameter("@BookId", SqlDbType.Int) { Value = salesDetail.BookId },
                    new SqlParameter("@Quantity", SqlDbType.Int) { Value = salesDetail.Quantity },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = salesDetail.Price }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray(), transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateSalesDetail failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteSalesDetail(int id, SqlTransaction transaction = null)
        {
            try
            {
                string query = @"DELETE FROM SalesDetails WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteSalesDetail failed: " + ex.Message);
                return false;
            }
        }

        public List<SalesDetail> GetAllSalesDetails()
        {
            try
            {
                string query = @"
                        SELECT Id, SaleId, BookId, Quantity, Price, Subtotal FROM SalesDetails";

                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<SalesDetail> selesDetails = new List<SalesDetail>();
                foreach (DataRow row in dt.Rows)
                {
                    selesDetails.Add(MapSalesDetail(row));
                }
                return selesDetails;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllSalesDetails failed: " + ex.Message);
                return new List<SalesDetail>();
            }
        }

        public SalesDetail? GetSalesDetailById(int id)
        {
            try
            {
                string query = @"
                        SELECT Id, SaleId, BookId, Quantity, Price, Subtotal FROM SalesDetails WHERE Id = @Id";

                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapSalesDetail(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetSalesDetailById failed: " + ex.Message);
                return null;
            }
        }

        public List<SalesDetail> GetSalesDetailBySaleId(int saleId)
        {
            try
            {
                string query = @"
                        SELECT Id, SaleId, BookId, Quantity, Price, Subtotal FROM SalesDetails WHERE SaleId = @SaleId";
                SqlParameter[] parameters = {
                    new SqlParameter("@SaleId", SqlDbType.Int) { Value = saleId }
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<SalesDetail> selesDetails = new List<SalesDetail>();
                foreach (DataRow row in dt.Rows)
                {
                    selesDetails.Add(MapSalesDetail(row));
                }
                return selesDetails;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetSalesDetailBySaleId failed: " + ex.Message);
                return new List<SalesDetail>();
            }
        }

        private SalesDetail MapSalesDetail(DataRow row)
        {
            return new SalesDetail
            {
                Id = Convert.ToInt32(row["Id"]),
                SaleId = Convert.ToInt32(row["SaleId"]),
                BookId = Convert.ToInt32(row["BookId"]),
                Quantity = Convert.ToInt32(row["Quantity"]),
                Price = Convert.ToDecimal(row["Price"]),
                //Subtotal = Convert.ToDecimal(row["Subtotal"])
            };
        }
    }
}
