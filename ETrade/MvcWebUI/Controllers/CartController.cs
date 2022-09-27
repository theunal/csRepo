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
  
    public class CartController : Controller
    {
        DataContext context = new DataContext();


        public ActionResult Index()
        {
            return View(GetCart());
        }


        public ActionResult AddToCart(int Id)   
        {
            var product = context.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
         
        public ActionResult RemoveCart(int Id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

      public ActionResult DecreaseCart(int Id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                GetCart().DecreaseProduct(product, 1);
            }

            return RedirectToAction("Index");
        }



        public CartModel GetCart()
        {
            var cart = (CartModel)Session["Cart"];
            if(cart == null)
            {
                cart = new CartModel();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult CartSummary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetailsModel());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetailsModel model)
        {
            var cart = GetCart();

            if (cart.CartLineModels.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(model);
            }
        }

        private void SaveOrder(CartModel cart, ShippingDetailsModel model)
        {
            Order order = new Order(); 
          
            order.OrderNumber = (new Random()).Next(111111111, 999999999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.UserName = User.Identity.Name;

            order.AdresTanimi = model.AdresTanimi;
            order.Adres = model.Adres;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.Orderlines = new List<OrderLine>();

            foreach (var product in cart.CartLineModels)
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = product.Quantity;
                orderline.Price = product.Quantity * product.Product.Price;
                orderline.ProductId = product.Product.Id;

                order.Orderlines.Add(orderline);
            }
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}