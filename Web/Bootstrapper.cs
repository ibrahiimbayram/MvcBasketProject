using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Business.Services;
using Web.Controllers;
using DataAcces.Interfaces;
using DataAcces.Repository;
using AutoMapper;

namespace Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IUsersDal,EfUsersRepository>();
            container.RegisterType<LoginServices>();
            container.RegisterType<IController, LoginController>("Login");

            return container;
        }
    }
}