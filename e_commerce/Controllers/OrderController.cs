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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var db = new e_commerceEntities1();
            var extorder= db.Orders.ToList();
            return View(extorder);
        }

        public ActionResult Cancel(int id) {
            var db = new e_commerceEntities1();
            var extorder = (from o in db.Orders where o.id == id select o).SingleOrDefault();
            extorder.Status = "Cancelled by Admin";
            var extorder2 = (from o in db.ProductOrders where o.oid == id select o).ToList();
            foreach (var item in extorder2)
            {
                var extproduct = (from p in db.products where item.pid == p.id select p).FirstOrDefault();
                extproduct.Qty = extproduct.Qty + item.qty;
               
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new e_commerceEntities1();
             var extorder = (from o in db.Orders where o.id == id select o).SingleOrDefault();
             db.Orders.Remove(extorder);
             var extorder2 = (from o in db.ProductOrders where o.oid == id select o).ToList();
             foreach (var item in extorder2)
             {
                 db.ProductOrders.Remove(item);
             }
             db.SaveChanges();
             return RedirectToAction("Index");
        }

        public ActionResult Processing(int id) {
            var db =new e_commerceEntities1();
            var extorder =(from o in db.Orders where o.id==id select o).SingleOrDefault();
            extorder.Status = "Processing";
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delivered(int id)
        {
            var db = new e_commerceEntities1();
            var extorder = (from o in db.Orders where o.id == id select o).SingleOrDefault();
            extorder.Status = "Delivered";
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}