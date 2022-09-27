using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibarnate
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                  new Product
                  {
                      ProductId = 17,ProductName = "ASUS LAPTOP",

                      CategoryId = 17, UnitsInStock = 3,UnitPrice = 9500,

                      QuantityPerUnit = "1 in a box"

                  }
            };
            return products;
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
