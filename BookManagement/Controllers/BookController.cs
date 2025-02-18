using System;
using System.Net;
using System.Web.Mvc;
using Models.Models;
using Services.Interfaces;

namespace BookManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        public ActionResult Index(int page = 1)
        {
            var books = _bookService.GetBooksWithPagination(page, Constants.PageSize);
            int totalBooks = _bookService.GetTotalBooksCount();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalBooks / Constants.PageSize);

            return View(books);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = _bookService.GetBookById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }

            ViewBag.CurrentPage = page;
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book, int page = 1)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("Index", new { page = page });
            }

            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = _bookService.GetBookById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
