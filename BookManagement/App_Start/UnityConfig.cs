using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
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

            container.RegisterType<IUnitOfWork, BookUnitOfWork>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryService, CategoryService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}