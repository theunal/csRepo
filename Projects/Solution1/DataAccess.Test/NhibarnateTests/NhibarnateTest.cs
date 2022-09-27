
using DataAccess.Concrete.Nhibarnate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataAccess.Test.NhibarnateTests
{
    [TestClass]
    public class NhibarnateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetAll();

            Assert.AreEqual(90, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetAll(p => p.ProductName.Contains("b"));

            Assert.AreEqual(31, result.Count);

        }
    }
}
