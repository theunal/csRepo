using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.NHibarnate;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.NHibarnate.Helper;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind<DbContext>().To<NorthwindContext>();

            Bind<NHibarnateHelper>().To<SqlServerHelper>();
        }
    }
}
