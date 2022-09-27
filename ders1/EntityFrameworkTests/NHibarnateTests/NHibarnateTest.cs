using DataAccess.Concrete.NHibarnate;
using DataAccess.Concrete.NHibarnate.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataAccessTests.NHibarnateTests
{
    [TestClass]
    public class NHibarnateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetAll();

            Assert.AreEqual(90, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filter()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetAll(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(3, result.Count);
        }
    }
}
