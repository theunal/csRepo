using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Postsharp;
using Core.Aspect.Postsharp.LogAspects;
using Core.Aspect.Postsharp.TransactionAspect;
using Core.Aspect.Postsharp.ValidationAspect;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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

        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            return productDal.GetAll();
      
        }
        public Product GetById(int id)
        {
            return productDal.Get(p => p.ProductId == id);
        }


        [FluentValiAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return productDal.Add(product);
        }

        [FluentValiAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            // ValidatorTool.FluentVali(new ProductValidator(), product);
            return productDal.Update(product);
        }





        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            productDal.Add(product1);
            // kodlar...
            productDal.Update(product2);
        }
    }
}
