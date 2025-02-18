using Models.Models;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}