using e_commerce.EF;
using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            db.Users.Add(model);
            db.SaveChanges();
            ViewBag.msg = "Registration Successfull";
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

            public ActionResult Login(Login model)
        {

            return View();
        }
    }
}