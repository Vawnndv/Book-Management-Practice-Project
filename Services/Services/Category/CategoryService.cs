using Infrastructure.Interfaces;
using Infrastructure.UnitOfWork;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public IEnumerable<Category> GetCategoriesWithPagination(int page, int pageSize)
        {
            return _unitOfWork.CategoryRepository.GetCategoriesWithPagination(page, pageSize);
        }

        public int GetTotalCategoriesCount()
        {
            return _unitOfWork.CategoryRepository.GetTotalCategoriesCount();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            if (CategoryExists(category.Name))
            {
                throw new InvalidOperationException("Category name already exists.");
            }

            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Complete();
        }

        public void UpdateCategory(Category category)
        {
            if (CategoryExists(category.Name))
            {
                throw new InvalidOperationException("Category name already exists.");
            }

            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Complete();
        }

        public void DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.Remove(id);
            _unitOfWork.Complete();
        }

        private bool CategoryExists(string name)
        {
            return _unitOfWork.CategoryRepository.CategoryExists(name);
        }
    }
}
