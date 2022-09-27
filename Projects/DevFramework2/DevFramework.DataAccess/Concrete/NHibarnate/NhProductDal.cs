using DevFramework.Core.DataAccess.NHibarnate;
using DevFramework.DataAccess.Abstract;
using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.DataAccess.Concrete.NHibarnate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        public NhProductDal(NHibernateHelper helper) : base(helper)
        {
        }
    }
}
