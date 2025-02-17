using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;
using BookManagement.Data;
using BookManagement.Models;
using BookManagement.Interfaces;

namespace BookManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Book
        public ActionResult Index(int page = 1)
        {
            var books = _unitOfWork.BookRepository.GetBooksWithPagination(page, Constants.PageSize);

            int totalBooks = _unitOfWork.BookRepository.GetTotalBooksCount();

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
                _unitOfWork.BookRepository.Add(book);
                _unitOfWork.Complete();
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

            Book book = _unitOfWork.BookRepository.GetById(id.Value);
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
                _unitOfWork.BookRepository.Update(book);
                _unitOfWork.Complete();
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

            Book book = _unitOfWork.BookRepository.GetById(id.Value);
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
            _unitOfWork.BookRepository.Remove(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
