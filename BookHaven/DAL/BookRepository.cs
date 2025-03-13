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
    class BookRepository
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public int CreateBook(Book book)
        {
            try
            {
                string query = @"
                        INSERT INTO Books (Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID, CreatedAt) 
                        OUTPUT INSERTED.Id
                        VALUES (@Title, @Author, @Genre, @ISBN, @Price, @StockQuantity, @SupplierID, @CreatedAt)";

                SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = book.Title },
                    new SqlParameter("@Author", SqlDbType.NVarChar) { Value = book.Author },
                    new SqlParameter("@Genre", SqlDbType.NVarChar) { Value = book.Genre ?? (object)DBNull.Value },
                    new SqlParameter("@ISBN", SqlDbType.NVarChar) { Value = book.ISBN },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = book.Price },
                    new SqlParameter("@StockQuantity", SqlDbType.Int) { Value = book.StockQuantity },
                    new SqlParameter("@SupplierID", SqlDbType.Int) { Value = book.SupplierID ?? (object)DBNull.Value },
                    new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = book.CreatedAt }
                };

                // Execute the query and return the inserted ID
                object result = _dbHelper.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Logger.LogError("CreateBook failed: " + ex.Message);
                return -1;
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                string query = @"
                        UPDATE Books SET Title = @Title, Author = @Author, Genre = @Genre, ISBN = @ISBN, Price = @Price, StockQuantity = @StockQuantity, SupplierID = @SupplierID WHERE Id = @Id";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = book.Id },
                    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = book.Title },
                    new SqlParameter("@Author", SqlDbType.NVarChar) { Value = book.Author },
                    new SqlParameter("@Genre", SqlDbType.NVarChar) { Value = book.Genre ?? (object)DBNull.Value },
                    new SqlParameter("@ISBN", SqlDbType.NVarChar) { Value = book.ISBN },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = book.Price },
                    new SqlParameter("@StockQuantity", SqlDbType.Int) { Value = book.StockQuantity },
                    new SqlParameter("@SupplierID", SqlDbType.Int) { Value = book.SupplierID ?? (object)DBNull.Value }
                };

                return _dbHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("UpdateBook failed: " + ex.Message);
                return false;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                string query = @"DELETE FROM Books WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = id }
                };
                return _dbHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                Logger.LogError("DeleteBook failed: " + ex.Message);
                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                string query = @"SELECT Id, Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID FROM Books";
                DataTable dt = _dbHelper.ExecuteQuery(query, new SqlParameter[] { });

                if (dt == null)
                {
                    throw new Exception("Database query returned null.");
                }

                List<Book> books = new List<Book>();
                foreach (DataRow row in dt.Rows)
                {
                    books.Add(MapBook(row));
                }
                return books;
            }
            catch (Exception ex)
            {
                Logger.LogError("GetAllBooks failed: " + ex.Message);
                return new List<Book>();
            }
        }

        public Book? GetBookById(int id)
        {
            try
            {
                string query = @"SELECT Id, Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID FROM Books WHERE Id = @Id";
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", id)
                };
                DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return MapBook(row);
            }
            catch (Exception ex)
            {
                Logger.LogError("GetBookById failed: " + ex.Message);
                return null;
            }
        }

        private Book MapBook(DataRow row)
        {
            return new Book
            {
                Id = Convert.ToInt32(row["Id"]),
                Title = row["Title"].ToString(),
                Author = row["Author"].ToString(),
                Genre = row["Genre"].ToString(),
                ISBN = row["ISBN"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                SupplierID = row["SupplierID"] != DBNull.Value ? Convert.ToInt32(row["SupplierID"]) : (int?)null,
            };
        }
    }
}
