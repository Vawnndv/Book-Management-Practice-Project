using BookManagement.Data;
using BookManagement.Interfaces;
using BookManagement.Repository;

namespace BookManagement.UnitOfWork
{
    public class BookUnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext _context;
        public IBookRepository BookRepository { get; private set; }

        public BookUnitOfWork(BookDbContext context)
        {
            _context = context;
            BookRepository = new BookRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
