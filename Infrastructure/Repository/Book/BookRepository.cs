using Infrastructure.Data;
using Infrastructure.Interfaces;
using Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(c => c.Category).OrderByDescending(b => b.Id).ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book Add(Book book)
        {
            _context.Books.Add(book);
            return book;
        }

        public Book Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            return book;
        }

        public Book Remove(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            return book;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetBooksWithPagination(int page, int pageSize)
        {
            return _context.Books.Include(c => c.Category)
                                 .OrderByDescending(b => b.Id)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();
        }

        public int GetTotalBooksCount()
        {
            return _context.Books.Count();
        }
    }
}