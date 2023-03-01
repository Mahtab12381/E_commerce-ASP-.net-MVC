using e_commerce.EF;
using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Registration(User model)
        {
            var db = new e_commerceEntities1();
            int count = 0;

            foreach (var item in db.Users)
            {
                if(item.Email == model.Email)
                {
                    count++;
                    ViewBag.msg = "Email Already Exists";
                }
            }
            if (count == 0)
            {
                db.Users.Add(model);
                db.SaveChanges();
                ViewBag.msg = "Registration Successfull";
            } 
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            var db = new e_commerceEntities1();
            var extuser= (from u in db.Users where u.Email==model.Email && u.Password==model.Password select u).SingleOrDefault();
            if (extuser != null)
            {
                Session["user"] = extuser;
                if (Request["ReturnUrl"]!=null)
                {
                    return Redirect(Request["ReturnUrl"]);
                } 
                else
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.msg = "Invalid User";
            }
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLogin model)
        {
            AdminLogin admin =new AdminLogin();
            admin.Email = "admin@mail.com";
            admin.Password = "888";
            if (admin.Email==model.Email && admin.Password==model.Password)
            {
                Session["admin"] = "admin";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.msg = "Invalid User";
            }
            return View();
        }
    }
}