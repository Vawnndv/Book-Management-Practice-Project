using Infrastructure.Interfaces;
using Infrastructure.UnitOfWork;
using Models.Models;
using System.Collections.Generic;

namespace Services.Services
{

    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> GetBooksWithPagination(int page, int pageSize)
        {
            return _unitOfWork.BookRepository.GetBooksWithPagination(page, pageSize);
        }

        public int GetTotalBooksCount()
        {
            return _unitOfWork.BookRepository.GetTotalBooksCount();
        }

        public Book GetBookById(int id)
        {
            return _unitOfWork.BookRepository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.Complete();
        }

        public void UpdateBook(Book book)
        {
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Complete();
        }

        public void DeleteBook(int id)
        {
            _unitOfWork.BookRepository.Remove(id);
            _unitOfWork.Complete();
        }
    }
}

