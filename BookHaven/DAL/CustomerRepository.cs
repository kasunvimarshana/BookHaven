using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHaven.DAL;
using BookHaven.Models;
using BookHaven.Utilities;
using BookHaven.Enums;

namespace BookHaven.DAL
{
    class CustomerRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public bool CreateCustomer(Customer customer, SqlTransaction transaction = null)
        {
            try
            {
                string query = "INSERT INTO Customers (FullName, Email, Phone, Address, CreatedAt) " +
                               "VALUES (@FullName, @Email, @Phone, @Address, @CreatedAt)";
                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = customer.FullName },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = customer.Email },
                    new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = customer.Phone },
                    new SqlParameter("@Address", SqlDbType.NVarChar) { Value = customer.Address },
                    new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = customer.CreatedAt }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateCustomer failed: " + ex.Message);
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer, SqlTransaction transaction = null)
        {
            try
            {
                string query = "UPDATE Customers SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = customer.Id },
                    new SqlParameter("@FullName", SqlDbType.NVarChar) { Value = customer.FullName },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = customer.Email },
                    new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = customer.Phone },
                    new SqlParameter("@Address", SqlDbType.NVarChar) { Value = customer.Address }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray(), transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateCustomer failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteCustomer(int id, SqlTransaction transaction = null)
        {
            try
            {
                string query = "DELETE FROM Customers WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters, transaction) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteCustomer failed: " + ex.Message);
                return false;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                string query = "SELECT Id, FullName, Email, Phone, Address, CreatedAt FROM Customers";
                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<Customer> customers = new List<Customer>();
                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(MapCustomer(row));
                }
                return customers;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllCustomers failed: " + ex.Message);
                return new List<Customer>();
            }
        }

        public Customer? GetCustomerById(int id)
        {
            try
            {
                string query = "SELECT Id, FullName, Email, Phone, Address, CreatedAt FROM Customers WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapCustomer(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetCustomerById failed: " + ex.Message);
                return null;
            }
        }

        private Customer MapCustomer(DataRow row)
        {
            return new Customer
            {
                Id = Convert.ToInt32(row["Id"]),
                FullName = row["FullName"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Phone"].ToString(),
                Address = row["Address"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }
    }
}
