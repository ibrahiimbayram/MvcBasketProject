using Business.Services;
using DataAcces.Interfaces;
using DataAcces.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver
{
   public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUsersDal>().To<EfUsersRepository>().InSingletonScope();

            Bind<IProductsDal>().To<EfProductsRepository>().InSingletonScope();

            Bind<ILanguageDal>().To<EfLanguageRepository>().InSingletonScope();

            Bind<IUserBasketDal>().To<EfUserBasketRepository>().InSingletonScope();
        }
    }
}
