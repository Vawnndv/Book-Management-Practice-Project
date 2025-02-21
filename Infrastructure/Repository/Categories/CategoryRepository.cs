using Infrastructure.Data;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _context;

        public CategoryRepository(BookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.OrderBy(n => n.Name).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            return category;
        }

        public Category Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            return category;
        }

        public Category Remove(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            return category;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategoriesWithPagination(int page, int pageSize)
        {
            return _context.Categories.OrderByDescending(b => b.Id)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();
        }

        public int GetTotalCategoriesCount()
        {
            return _context.Categories.Count();
        }

        public bool CategoryExists(string name)
        {
            return _context.Categories.Any(c => c.Name.ToLower().Equals(name.ToLower(), StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Book> GetBooksByCategoryId(int categoryId)
        {
            return _context.Books.Where(b => b.CategoryId == categoryId).ToList();
        }

    }
}
