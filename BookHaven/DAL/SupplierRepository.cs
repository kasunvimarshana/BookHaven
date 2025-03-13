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
    class SupplierRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public int CreateSupplier(Supplier supplier)
        {
            try
            {
                string query = @"
                            INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address, CreatedAt)
                            OUTPUT INSERTED.Id
                            VALUES (@Name, @ContactPerson, @Phone, @Email, @Address, @CreatedAt)";
                SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = supplier.Name },
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar) { Value = supplier.ContactPerson },
                    new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = supplier.Phone },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = supplier.Email },
                    new SqlParameter("@Address", SqlDbType.NVarChar) { Value = supplier.Address },
                    new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = supplier.CreatedAt }
                };

                // Execute the query and return the inserted ID
                object result = _dbHelper.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateSupplier failed: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            try
            {
                string query = "UPDATE Suppliers SET Name = @Name, ContactPerson = @ContactPerson, Phone = @Phone, Email = @Email, Address = @Address WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = supplier.Id },
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = supplier.Name },
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar) { Value = supplier.ContactPerson },
                    new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = supplier.Phone },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = supplier.Email },
                    new SqlParameter("@Address", SqlDbType.NVarChar) { Value = supplier.Address }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateSupplier failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteSupplier(int id)
        {
            try
            {
                string query = "DELETE FROM Suppliers WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteSupplier failed: " + ex.Message);
                return false;
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            try
            {
                string query = "SELECT Id, Name, ContactPerson, Phone, Email, Address, CreatedAt FROM Suppliers";
                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<Supplier> suppliers = new List<Supplier>();
                foreach (DataRow row in dt.Rows)
                {
                    suppliers.Add(MapSupplier(row));
                }
                return suppliers;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllSuppliers failed: " + ex.Message);
                return new List<Supplier>();
            }
        }

        public Supplier? GetSupplierById(int id)
        {
            try
            {
                string query = "SELECT Id, Name, ContactPerson, Phone, Email, Address, CreatedAt FROM Suppliers WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapSupplier(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetSupplierById failed: " + ex.Message);
                return null;
            }
        }

        private Supplier MapSupplier(DataRow row)
        {
            return new Supplier
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                ContactPerson = row["ContactPerson"].ToString(),
                Phone = row["Phone"].ToString(),
                Email = row["Email"].ToString(),
                Address = row["Address"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }
    }
}
