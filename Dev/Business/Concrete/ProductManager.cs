using Business.Abstract;
using Business.ValidaitonRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : ProductService
    {

        IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }




        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return productDal.GetList(filter);
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return productDal.Get(filter);
        }









        [ProductValidationAspect(typeof(ProductValidator))]
        public Product Add(Product entity)
        {
            return productDal.Add(entity);
        }
        public Product Update(Product entity)
        {
            return productDal.Update(entity);
        }

        public void Delete(Product entity)
        {
            productDal.Delete(entity);
        }





    }
}
