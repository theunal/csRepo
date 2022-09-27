using Business.Abstract;
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
    }
}