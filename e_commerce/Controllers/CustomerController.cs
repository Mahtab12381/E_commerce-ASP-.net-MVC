using e_commerce.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace e_commerce.Controllers
{
    public class CustomerController : Controller
    {
        public int user_id = 2002;

        // GET: Customer
        public ActionResult Index()
        {
            var db = new e_commerceEntities1();
            var extproduct = db.products.ToList();
            return View(extproduct);
        }



        public ActionResult Add_to_Cart(int id) {
           
            var db = new e_commerceEntities1();
            var extorder = (from o in db.Orders where o.uid == user_id && o.Status.Equals("pending") select o).SingleOrDefault();
            var extproduct = (from p in db.products where p.id == id select p).SingleOrDefault();
            if (extorder == null) {             
                Order order = new Order();
                order.uid = user_id;
                order.Amount = extproduct.Price;
                order.Date = DateTime.Today;
                order.Status = "pending";
                db.Orders.Add(order);
                db.SaveChanges();
            }
            var extorder2 = (from o in db.Orders where o.uid == user_id && o.Status.Equals("pending") select o).SingleOrDefault();
            ProductOrder productorder = new ProductOrder();
            productorder.pid= extproduct.id;
            productorder.oid=extorder2.id;
            productorder.qty = 1;
            db.ProductOrders.Add(productorder);
            extproduct.Qty= extproduct.Qty - 1;
            db.SaveChanges();
            TempData["msg"] = "Successfully Added to cart";
           return RedirectToAction("Index");
        }

        public ActionResult CartShow()
        {
            var db = new e_commerceEntities1();
            var extorder = (from o in db.Orders where o.uid == user_id && o.Status.Equals("pending") select o).SingleOrDefault();
            return View(extorder);
        }

        public ActionResult EmptyCart(int id)
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
            return RedirectToAction("CartShow");
        }
        public ActionResult PlaceOrder(int id)
        {
            var db = new e_commerceEntities1(); 
            var extorder = (from o in db.Orders where o.uid == user_id && o.Status.Equals("pending") select o).SingleOrDefault();
            extorder.Status = "Order Placed";
            db.SaveChanges();
            return RedirectToAction("OrderHistory");
        }

        public ActionResult OrderHistory()
        {
            var db = new e_commerceEntities1();
            var extorder = (from o in db.Orders where o.uid == user_id && !o.Status.Equals("pending") select o).ToList();
            return View(extorder);
        }
    }
}