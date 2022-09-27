using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Postsharp;
using Core.Aspects.Postsharp.AuthorizationAspects;
using Core.Aspects.Postsharp.CacheAspects;
using Core.Aspects.Postsharp.LogAspects;
using Core.Aspects.Postsharp.TransactionAspects;
using Core.Aspects.Postsharp.ValidationAspects;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.Log4net.Loggers;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        [SecuredOperation(Roles="Admin")]
        public List<Product> GetAll()
        {
            Thread.Sleep(5000);
            return productDal.GetList();

        }
        public Product GetById(int id)
        {
            return productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return productDal.Add(product);
        }


        public Product Update(Product product)
        {

            return productDal.Update(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            productDal.Add(product1);
            productDal.Update(product2);
        }
    }
}
