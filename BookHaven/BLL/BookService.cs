using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.DAL;
using BookHaven.Models;

namespace BookHaven.BLL
{
    class BookService
    {
        private readonly BookRepository _bookRepo = new BookRepository();

        public List<Book> GetAllBooks() => _bookRepo.GetAllBooks();

        public Book? GetBookById(int id) => _bookRepo.GetBookById(id);

        public int CreateBook(Book supplier)
            => _bookRepo.CreateBook(supplier);

        public bool UpdateBook(Book supplier)
            => _bookRepo.UpdateBook(supplier);

        public bool DeleteBook(int id) => _bookRepo.DeleteBook(id);
    }
}
