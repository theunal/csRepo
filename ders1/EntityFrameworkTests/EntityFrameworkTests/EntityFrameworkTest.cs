using DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataAccessTests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetAll();
          
            Assert.AreEqual(90, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filter()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetAll(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(3, result.Count);
        }
    }
}
