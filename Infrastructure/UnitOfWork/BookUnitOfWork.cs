using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class BookUnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext _context;
        public IBookRepository BookRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }

        public BookUnitOfWork(BookDbContext context)
        {
            _context = context;
            BookRepository = new BookRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
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
