using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Services.Interfaces;
using Services.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BookManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IUnitOfWork, BookUnitOfWork>();
            container.RegisterType<IBookService, BookService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}