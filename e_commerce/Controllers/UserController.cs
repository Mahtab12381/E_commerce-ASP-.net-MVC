using e_commerce.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User model)
        {
            var db = new e_commerceEntities1();
            db.Users.Add(model);
            db.SaveChanges();
            ViewBag.msg = "Added";
            return View();
        }

        public ActionResult UserList() {
            var db = new e_commerceEntities1();
            var extusers=db.Users.ToList();
            return View(extusers);
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var db = new e_commerceEntities1();
            var extUser = (from u in db.Users where u.id == id select u).SingleOrDefault();
            return View(extUser);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            var db = new e_commerceEntities1();
            var extUser = (from u in db.Users where u.id == model.id select u).SingleOrDefault();
            extUser.Email = model.Email;
            extUser.Name= model.Name;
            extUser.Password= model.Password;
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

        public ActionResult Delete(int id)
        {
            var db = new e_commerceEntities1();
            var extUser = (from u in db.Users where u.id == id select u).SingleOrDefault();
            db.Users.Remove(extUser);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }
    }
}