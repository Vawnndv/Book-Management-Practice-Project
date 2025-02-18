using Infrastructure.Interfaces;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void Complete();
    }
}

