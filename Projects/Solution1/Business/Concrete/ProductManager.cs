using Business.Absract;
using Business.ValidationRules.FluentValdation;
using Core.Aspects.Postsharp;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {
            return productDal.GetAll();
        }
        public Product GetById(int id)
        {
            return productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperations(Product product1, Product product2)
        {
            productDal.Add(product1);
            // business code
            productDal.Update(product2);
        }


    }
}
