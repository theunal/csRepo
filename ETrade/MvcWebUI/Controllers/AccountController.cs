using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebUI.Identity;
using MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MvcWebUI.Identity.Context;
using MvcWebUI.Entity.Context;

namespace MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        DataContext context = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = context.Orders.Where(p => p.UserName == username)
                .Select(p => new UserOrderModel()
                {
                    Id = p.Id,
                    OrderNumber = p.OrderNumber,
                    OrderDate = p.OrderDate,
                    OrderState = p.OrderState,
                    Total = p.Total
                }).OrderByDescending(p => p.OrderDate).ToList();

            return View(orders);
        }


        [Authorize]
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





        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabilirsiniz.
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı  oluşturma hatası.");
                }

            }

            return View(model);
        }



        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}