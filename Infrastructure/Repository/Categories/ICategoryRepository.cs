using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category);
        Category Update(Category category);
        Category Remove(int id);
        void Save();

        IEnumerable<Category> GetCategoriesWithPagination(int page, int pageSize);
        int GetTotalCategoriesCount();
        bool CategoryExists(string name);
    }
}
