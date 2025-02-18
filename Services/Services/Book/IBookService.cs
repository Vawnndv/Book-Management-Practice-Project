using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooksWithPagination(int page, int pageSize);
        int GetTotalBooksCount();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
