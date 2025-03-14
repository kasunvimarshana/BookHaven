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
    class BookService
    {
        private readonly BookRepository _bookRepo = new BookRepository();

        public List<Book> GetAllBooks() => _bookRepo.GetAllBooks();

        public Book? GetBookById(int id) => _bookRepo.GetBookById(id);

        public int CreateBook(Book supplier, SqlTransaction transaction = null)
            => _bookRepo.CreateBook(supplier, transaction);

        public bool UpdateBook(Book supplier, SqlTransaction transaction = null)
            => _bookRepo.UpdateBook(supplier, transaction);

        public bool DeleteBook(int id, SqlTransaction transaction = null) => _bookRepo.DeleteBook(id, transaction);
    }
}
