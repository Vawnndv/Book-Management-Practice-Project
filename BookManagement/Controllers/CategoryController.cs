using Models.Models;
using Services.Services;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookManagement.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index(int page = 1)
        {
            var categories = _categoryService.GetCategoriesWithPagination(page, Constants.PageSize);
            int totalCategories = _categoryService.GetTotalCategoriesCount();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCategories / Constants.PageSize);

            string message = TempData["ErrorMessage"] as string;
            TempData["ErrorMessage"] = message;
            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    category.Name = category.Name.Trim();

                    _categoryService.AddCategory(category);
                    return RedirectToAction("Index");
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }

            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _categoryService.GetCategoryById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.CurrentPage = page;
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category, int page = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    category.Name = category.Name.Trim();

                    _categoryService.UpdateCategory(category);
                    return RedirectToAction("Index", new { page = page });
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Name", ex.Message);
                }
            }

            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _categoryService.GetCategoryById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);
                if (category != null)
                {
                    var dependentBooks = _categoryService.GetBooksByCategoryId(id);
                    if (dependentBooks.Any())
                    {
                        TempData["ErrorMessage"] = "This category is associated with one or more books and cannot be deleted.";
                        return RedirectToAction("Index");
                    }
                    _categoryService.DeleteCategory(id);
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
