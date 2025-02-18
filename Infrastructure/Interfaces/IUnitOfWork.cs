using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        void Complete();
    }
}

