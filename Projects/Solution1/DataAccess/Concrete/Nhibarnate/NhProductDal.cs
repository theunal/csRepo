using Core.DataAccess.Nhibarnate;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Nhibarnate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
    

        public NhProductDal(NhibarnateHelper nhibarnateHelper) : base(nhibarnateHelper)
        {
        }
    }
}
