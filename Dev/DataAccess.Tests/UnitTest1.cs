using DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetList()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList();

            Assert.AreEqual(80, result.Count);
        }



        [TestMethod]
        public void GetListWithFilter()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
