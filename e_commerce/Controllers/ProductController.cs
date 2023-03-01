using e_commerce.Auth;
using e_commerce.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce.Controllers
{
    [AdminLogged]
    public class ProductController : Controller
    {
        [HttpGet]
        // GET: Product
        public ActionResult Index()
        {
            var db = new e_commerceEntities1();
            var option = db.Cetegories.ToList();
            ViewBag.option = option;
            return View();
        }

        [HttpPost]
        public ActionResult Index(product model)
        {
            var db = new e_commerceEntities1();
            db.products.Add(model);
            db.SaveChanges();
            ViewBag.msg = "Added";
            var option = db.Cetegories.ToList();
            ViewBag.option = option;
            return View();
        }

        public ActionResult List()
        {
            var db = new e_commerceEntities1();
            var extproduct = db.products.ToList();
            return View(extproduct);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new e_commerceEntities1();
            var extproduct = (from p in db.products where p.id == id select p).SingleOrDefault();

            var option = db.Cetegories.ToList();
            ViewBag.option = option;
            return View(extproduct);
        }
        [HttpPost]
        public ActionResult Edit(product model)
        {
            var db = new e_commerceEntities1();
            var extproduct = (from p in db.products where p.id == model.id select p).SingleOrDefault();
            extproduct.Name = model.Name;
            extproduct.Price = model.Price;
            extproduct.Qty = model.Qty;
            extproduct.cid = model.cid;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var db = new e_commerceEntities1();
            var extproduct = (from p in db.products where p.id == id select p).SingleOrDefault();
            db.products.Remove(extproduct);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Cetegory()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Cetegory(Cetegory model)
        {
            var db = new e_commerceEntities1();
            db.Cetegories.Add(model);   
            db.SaveChanges();
            ViewBag.msg = "Added";
            return View();
        }
        public ActionResult ListCetegory() {
            var db = new e_commerceEntities1();
            var extcetegory = db.Cetegories.ToList();
            return View(extcetegory);
        }

        public ActionResult DeleteCetegory(int id)
        {
            var db = new e_commerceEntities1();
            var extCetegory= (from c in db.Cetegories where c.id==id select c).SingleOrDefault();
            db.Cetegories.Remove(extCetegory);
            db.SaveChanges();
            return RedirectToAction("ListCetegory");
        }
    }
}