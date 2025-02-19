using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetCategoriesWithPagination(int page, int pageSize);
        int GetTotalCategoriesCount();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
