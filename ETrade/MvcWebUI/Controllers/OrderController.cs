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
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult Index()
        {

            var orders = context.Orders.Select(p => new AdminOrderModel()
            {
                Id = p.Id,
                OrderDate = p.OrderDate,
                OrderNumber = p.OrderNumber,
                OrderState = p.OrderState,
                Total = p.Total,

            }).OrderByDescending(p => p.OrderDate).ToList();

            return View(orders);
        }


        public ActionResult Details(int id)
        {
            var entity = context.Orders.Where(p => p.Id == id)
                .Select(p => new OrderDetailsModel()
                {
                    OrderId = p.Id,
                    OrderNumber = p.OrderNumber,
                    Total = p.Total,
                    OrderDate = p.OrderDate,
                    OrderState = p.OrderState,
                    UserName = p.UserName,

                    AdresTanimi = p.AdresTanimi,
                    Adres = p.Adres,
                    Sehir = p.Sehir,
                    Semt = p.Semt,
                    Mahalle = p.Mahalle,
                    PostaKodu = p.PostaKodu,

                    Orderlines = p.Orderlines.Select(i => new OrderLineModel()
                    {
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        Price = i.Price,
                        Quantity = i.Quantity,
                        Image = i.Product.image
                        
                    }).ToList()

                }).FirstOrDefault();

            return View(entity);
        }



        public ActionResult UpdateOrderState(int OrderId, EnumOrderState orderState)
        {
            var order = context.Orders.Where(p => p.Id == OrderId).FirstOrDefault();
            if(order != null)
            {
                order.OrderState = orderState;
                context.SaveChanges();



                TempData["mesaj"] = "Değişiklikler kaydedildi.";
                return RedirectToAction("/Details", new {id = OrderId});

             
            }

            return RedirectToAction("Index");
        }
    }
}