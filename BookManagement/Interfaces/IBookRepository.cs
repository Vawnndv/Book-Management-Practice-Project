using BookManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagement.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Remove(int id);
        void Save();

        IEnumerable<Book> GetBooksWithPagination(int page, int pageSize);
        int GetTotalBooksCount();
    }

}
