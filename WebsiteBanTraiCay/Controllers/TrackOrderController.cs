using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanTraiCay.Models;

namespace WebsiteBanTraiCay.Controllers
{
    public class TrackOrderController : Controller
    {
        private ConnectDbContext db = new ConnectDbContext();
        // GET: TrackOrder
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string phoneNumber = fc["phone"].ToString();
            var listOrder = db.Orders.Where(m => m.DeliveryPhone.Equals(phoneNumber)).OrderByDescending(m => m.ID).ToList();
            return View("listOrders", listOrder);
        }
        public ActionResult DetailOrder(int id)
        {
            var checkO = db.Orders.Where(m => m.Status !=0).ToList();
            if (checkO.Count() == 0)
            {
                
            }

            var id_order = db.Orders.Where(m => m.Status != 0).FirstOrDefault();
            ViewBag.Order = id_order;
            var itemOrder = db.Orderdetails.Where(m => m.OrderID == id_order.ID).ToList();
            ViewBag.productOrder = db.Products.ToList();
            return View(itemOrder);
            
        }
        public ActionResult productDetailCheckOut(int orderId)
        {
            var list = db.Orderdetails.Where(m => m.OrderID == orderId).ToList();
            return View("_productDetailCheckOut", list);

        }
        public ActionResult subnameProduct(int id)
        {
            var list = db.Products.Find(id);
            return View("_subproductOrdersuccess", list);

        }
    }
}