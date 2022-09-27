using Business.Abstract;
using Entities.Concrete;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = productService.GetAll()

            };

            return View(model);
        }

        public string Add()
        {
            productService.Add(new Product {

                CategoryId = 1,
                ProductName = "iPhone 7",
                QuantityPerUnit = "3",
                UnitPrice = 6499
                
            });
            return "Ürün eklendi: iPhone 7";
        }

        public string AddandUpdate()
        {

            productService.TransactionalOperation(new Product
            {
                // add
                CategoryId = 1,
                ProductName = "iPhone 13 Pro",
                QuantityPerUnit = "99",
                UnitPrice = 5

            }, new Product
            {
                // update
                ProductId = 2,
                CategoryId = 1,
                ProductName = "iPhone 8 plus",
                QuantityPerUnit = "45",
                UnitPrice = 8999

            });

            return "bitti";
        }
    }
}