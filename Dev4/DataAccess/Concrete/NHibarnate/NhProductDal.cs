using Core.DataAccess.NHibarnate;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.NHibarnate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private NHibarnateHelper helper;
        public NhProductDal(NHibarnateHelper helper) : base(helper)
        {
            this.helper = helper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = helper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                             };
                return result.ToList();
            }
        }
    }
}
