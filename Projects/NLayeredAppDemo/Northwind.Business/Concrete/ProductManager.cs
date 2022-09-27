using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.NHibarnate;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //eski kod bagımlı-- ProductDal productManager = new ProductDal();
        // IProductDal productDal = new NhProductDal();

        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return this.productDal.GetAll();
         

        }
    }
}
