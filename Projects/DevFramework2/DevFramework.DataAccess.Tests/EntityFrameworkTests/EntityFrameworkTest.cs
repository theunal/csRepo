using DevFramework.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();

            Assert.AreEqual(90, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(3, result.Count);
        }



        // category
        [TestMethod]
        public void Get_all_returns_all_categories()
        {
            EfCategoryDal productDal = new EfCategoryDal();
            var result = productDal.GetList();

            Assert.AreEqual(8, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_category()
        {
            EfCategoryDal productDal = new EfCategoryDal();
            var result = productDal.GetList(p => p.CategoryName.Contains("e"));

            Assert.AreEqual(7, result.Count);
        }
    }
}
