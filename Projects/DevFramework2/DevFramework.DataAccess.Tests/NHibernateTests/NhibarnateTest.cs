using DevFramework.DataAccess.Concrete.NHibarnate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NhibarnateTest
    {
        // product
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();

            Assert.AreEqual(90, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(3, result.Count);
        }



        // category
        [TestMethod]
        public void Get_all_returns_all_categories()
        {
            NhCategoryDal productDal = new NhCategoryDal(new SqlServerHelper());
            var result = productDal.GetList();

            Assert.AreEqual(8, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_category()
        {
            NhCategoryDal productDal = new NhCategoryDal(new SqlServerHelper());
            var result = productDal.GetList(p => p.CategoryName.Contains("e"));

            Assert.AreEqual(7, result.Count);
        }
    }
}
