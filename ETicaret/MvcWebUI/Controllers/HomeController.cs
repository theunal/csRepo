using MvcWebUI.Entity;
using MvcWebUI.Entity.Context;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();

        public ActionResult Index()
        {
            var urunler = context.Products.
                Where(p => p.IsHome == true && p.IsApproved == true).
                Select(p => new ProductModel()
                {
                    Id = p.Id,
                    Name = p.Name.Length > 50 ? p.Name.Substring(0, 50) + "..." : p.Name,
                    Description = p.Description.Length > 50 ? p.Description.Substring(0, 50) + "..." : p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    image = p.image,
                    CategoryId = p.CategoryId
                }).ToList();



            return View(urunler);
        }


        public ActionResult ProductList(int? id)
        {
            var urunler = context.Products.
                Where(p => p.IsApproved == true).
                Select(p => new ProductModel()
                {
                    Id = p.Id,
                    Name = p.Name.Length > 50 ? p.Name.Substring(0, 50) + "..." : p.Name,
                    Description = p.Description.Length > 100 ? p.Description.Substring(0, 100) + "..." : p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    image = p.image,
                    CategoryId = p.CategoryId
                }).AsQueryable();

            if (id != null)
            {
                urunler = urunler.Where(p => p.CategoryId == id);
            }


            return View(urunler.ToList());
        }

        public ActionResult Details(int id)
        {
            var urun = context.Products.Where(p => p.Id == id).SingleOrDefault();
            return View(urun);
        }


        public PartialViewResult GetCategory()
        {
         
            return PartialView(context.Categories.ToList());

        }


    }
}
