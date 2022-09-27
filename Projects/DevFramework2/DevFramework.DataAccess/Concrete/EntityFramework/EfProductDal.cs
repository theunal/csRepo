using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
    {
    }
}
