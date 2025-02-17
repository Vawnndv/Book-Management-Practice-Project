using BookManagement.Interfaces;
using BookManagement.Repository;
using BookManagement.UnitOfWork;
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

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}