using Business.Abstract;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }






        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            productDal.Add(product);
        }
        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            productDal.Update(product);
        }

        public void Delete(Product product)
        {
            productDal.Delete(product);
        }








        public List<Product> GetAll()
        {
            return this.productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int CategoryID)
        {
            return productDal.GetAll(p => p.CategoryId == CategoryID);
        }

        public List<Product> GetProductsByProductName(string text)
        {
            return productDal.GetAll(p => p.ProductName.ToLower().Contains(text.ToLower()));
        }

        
    }
}
