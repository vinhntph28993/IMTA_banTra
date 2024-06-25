using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.UI.WebControls;
using WebsiteBanTraiCay.Library;
using WebsiteBanTraiCay.Models;
using WebsiteBanTraiCay.MomoAPI;

namespace WebsiteBanTraiCay.Controllers
{
    public class CartController : Controller
    {
        private ConnectDbContext db = new ConnectDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int pid, int qty)
        {
            var p = db.Products.Where(m => m.Status == 1 && m.ID == pid).First();

            var cart = Session["Cart"];
            if (cart == null)
            {
                var item = new ModelCart();
                item.ProductID = p.ID;
                item.Name = p.Name;
                item.Slug = p.Slug;
                item.Image = p.Image;
                item.Quantity = qty;
                item.Price = p.Price;
                var list = new List<ModelCart>();
                list.Add(item);

                Session["Cart"] = list;
                return Json(new { result = 1 });
            }
            else
            {
                var list = (List<ModelCart>)cart;

                if (list.Exists(m => m.ProductID == pid))
                {
                    foreach (var item in list)
                    {
                        if (item.ProductID == pid)
                            item.Quantity += qty;
                        return Json(new { result = 2 });
                    }
                }
                else
                {
                    var item = new ModelCart();
                    item.ProductID = p.ID;
                    item.Name = p.Name;
                    item.Slug = p.Slug;
                    item.Image = p.Image;
                    item.Quantity = qty;
                    item.Price = p.Price;
                    list.Add(item);
                    return Json(new { result = 1 });
                }
            }
            return Json(new { result = 0 });
        }

        public JsonResult Update(int pid, String option)
        {
            var sCart = (List<ModelCart>)Session["Cart"];
            ModelCart c = sCart.First(m => m.ProductID == pid);
            var product = db.Products.Find(pid);
            if (c != null && product != null)
            {
                switch (option)
                {
                    case "add":
                        c.Quantity++;
                        if (c.Quantity > product.Quantity)
                        {
                            c.Quantity = product.Quantity;
                            return Json(10);
                        }
                        return Json(1);
                    case "minus":
                        if (c.Quantity == 1)
                        {
                            return Json(11);
                        }
                        c.Quantity--;
                        return Json(2);
                    case "remove":
                        sCart.Remove(c);
                        if (sCart.Count() == 0)
                            Session.Remove("Cart");
                        return Json(3);
                    default:
                        break;
                }
            }
            return Json(null);
        }
        public ActionResult RemoveAll()
        {
            Session.Remove("Cart");
            Notification.set_flash("Đã xóa toàn bộ sản phẩm trong giỏ hàng!", "success");
            return Redirect("~/cart");
        }
        public ActionResult Checkout()
        {
            if (Session["User_Name"] != null && Session["Cart"] != null)
            {
                int user_id = Convert.ToInt32(Session["User_ID"]);
                ViewBag.Info = db.UserGoogle.Where(m => m.ID == user_id).First();
            }
            else
                return RedirectToAction("Index", "Cart");
            return View();
        }

        [HttpPost]
        public JsonResult Payment(String Address, String FullName, String Phone, String Email, String CodeVoucher)
        {
            MVoucher voucher = db.Vouchers.FirstOrDefault(x => x.Name.Equals(CodeVoucher) && x.Status != 0);
            if (voucher != null)
            {
                if (voucher.Quantity == 0)
                {
                    Notification.set_flash("Voucher hết số lượng!", "error");
                    return Json(false);
                }
                else if (DateTime.Now > DateTime.Parse(voucher.DateExpire) && voucher.Quantity != 0)
                {
                    Notification.set_flash("Voucher hết hạn sử dụng!", "error");
                    return Json(false);
                }
                else if (DateTime.Now <= DateTime.Parse(voucher.DateExpire) && voucher.Quantity != 0)
                {
                    var orderV = new MOrder();
                    int user_idV = Convert.ToInt32(Session["User_ID"]);

                    orderV.Code = DateTime.Now.ToString("yyyyMMddhhMMss"); // yyyy-MM-dd hh:MM:ss
                    orderV.UserID = user_idV;
                    orderV.CreateDate = DateTime.Now;
                    orderV.DeliveryAddress = Address;
                    orderV.DeliveryEmail = Email;
                    orderV.DeliveryPhone = Phone;
                    orderV.DeliveryName = FullName;
                    orderV.Status = 1;
                    orderV.IsPayment = false;
                    db.Orders.Add(orderV);
                    voucher.Quantity = voucher.Quantity - 1;
                    db.SaveChanges();

                    var OrderIDV = orderV.ID;

                    var discountkm = 1 - (((double)voucher.Discount) / 100);

                    foreach (var c in (List<ModelCart>)Session["Cart"])
                    {
                        var orderdetails = new MOrderDetail();
                        orderdetails.OrderID = OrderIDV;
                        orderdetails.ProductID = c.ProductID;
                        orderdetails.Price = c.Price;
                        orderdetails.Quantity = c.Quantity;
                        orderdetails.Amount = c.Price * c.Quantity * discountkm;
                        db.Orderdetails.Add(orderdetails);
                    }
                    db.SaveChanges();

                    Session.Remove("Cart");
                    MailHelper helperV = new MailHelper();
                    helperV.SendMail(Email,
            "[VinFruits] THÔNG BÁO XÁC NHẬN ĐƠN HÀNG",
                            "Xin chào"
                            +
                            orderV.DeliveryName
                            +
                            "VinFruits vừa nhận được đơn đặt hàng từ bạn, "
                            +
                            "chúng tôi sẽ gọi bạn để xác minh thông tin đặt hàng sớm nhất có thể."
                            +
                            "Cảm ơn bạn đã mua sản phẩm tại website, Chúc bạn một ngày tốt lành"
                            + "<h4>" + "THÔNG TIN KHÁCH HÀNG" + "</h4>"
                            + "<div>"
                            + "<label>" + "Họ tên khách hàng: " + "</label>"
                            + "<span>" + orderV.DeliveryName + "</span>"
                            + "</div>"
                            + "<div>"
                            + "<label>" + "Số điện thoại đặt hàng: " + "</label>"
                            + "<span>" + orderV.DeliveryPhone + "</span>"
                            + "</div>"
                            + "<div>"
                            + "<label>" + "Email đặt hàng: " + "</label>"
                            + "<span>"
                            + orderV.DeliveryEmail
                            + "</span>"
                            + "</div>"
                            + "<div>"
                            + "<label>" + "Địa chỉ nhận hàng: " + "</label>"
                            + "<span>"
                            + orderV.DeliveryAddress
                            + "</span>"
                            + "</div>"
                            + "<br/>"
                            );
                    Notification.set_flash("Bạn đã đặt hàng thành công!", "success");
                    return Json(true);
                }
            }
            
            var order = new MOrder();
            int user_id = Convert.ToInt32(Session["User_ID"]);

            order.Code = DateTime.Now.ToString("yyyyMMddhhMMss"); // yyyy-MM-dd hh:MM:ss
            order.UserID = user_id;
            order.CreateDate = DateTime.Now;
            order.DeliveryAddress = Address;
            order.DeliveryEmail = Email;
            order.DeliveryPhone = Phone;
            order.DeliveryName = FullName;
            order.Status = 1;
            order.IsPayment = false;
            db.Orders.Add(order);
            db.SaveChanges();

            var OrderID = order.ID;



            foreach (var c in (List<ModelCart>)Session["Cart"])
            {

                var orderdetails = new MOrderDetail();
                orderdetails.OrderID = OrderID;
                orderdetails.ProductID = c.ProductID;
                orderdetails.Price = c.Price;
                orderdetails.Quantity = c.Quantity;
                orderdetails.Amount = c.Price * c.Quantity ;
                db.Orderdetails.Add(orderdetails);
            }
            db.SaveChanges();

            Session.Remove("Cart");
            MailHelper helper = new MailHelper();
            helper.SendMail(Email,
            "[VinFruits] THÔNG BÁO XÁC NHẬN ĐƠN HÀNG",
                            "Xin chào: "
                            +
                            order.DeliveryName
                            +
                            "VinFruits vừa nhận được đơn đặt hàng từ bạn, "                         
                            +"<br/>"
                            +"chúng tôi sẽ gọi bạn để xác minh thông tin đặt hàng sớm nhất có thể."
                            +"<br/>"
                            +
                            "Cảm ơn bạn đã mua sản phẩm tại website, Chúc bạn một ngày tốt lành"
                            + "<h4>" + "THÔNG TIN KHÁCH HÀNG" + "</h4>"
                            + "<div>"
                            + "<label>" + "Họ tên khách hàng: " + "</label>"
                            + "<span>" + order.DeliveryName + "</span>"
                            + "</div>"
                            + "<div>"
                            + "<label>" + "Số điện thoại đặt hàng: " + "</label>"
                            + "<span>" + order.DeliveryPhone + "</span>"
                            + "</div>"
                            + "<div>"
                            + "<label>" + "Email đặt hàng: " + "</label>"
                            + "<span>"
                            + order.DeliveryEmail
                            + "</span>"
                            + "</div>"
                            + "<div>"
                            + "<label>" + "Địa chỉ nhận hàng: " + "</label>"
                            + "<span>"
                            + order.DeliveryAddress
                            + "</span>"
                            + "</div>"
                            + "<br/>"
                            );
            Notification.set_flash("Bạn đã đặt hàng thành công!", "success");
            return Json(true);
        }
        public JsonResult Tesst()
        {
            if (Session["User_Name"] != null)
                return Json(1);
            return Json(0);
        }
        public JsonResult CheckAuth()
        {
            if (Session["User_Name"] != null)
                return Json(1);
            return Json(0);
        }

        public ActionResult PaymentMoMo(int id)
        {
            var obj = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            var listObjDetail = db.Orderdetails.Where(x => x.OrderID == id).ToList();
            double total = 0;
            foreach (var item in listObjDetail)
            {
                total += item.Amount;
            }
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Thanh toán cho đơn hàng tại web";
            string returnUrl = "https://localhost:44370/account/order";
            string notifyurl = "http://ba1adf48beba.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = total.ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            obj.IsPayment = true;
            db.SaveChanges();
            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

        [HttpPost]
        public void SavePayment()
        {
            //cập nhật dữ liệu vào db
        }

        public ActionResult CancelOrder(int id)
        {
            var order = new MOrder();
            var obj = db.Orders.FirstOrDefault(x => x.ID == id);
            obj.Status = 0;
            db.SaveChanges();
            MailHelper helper = new MailHelper();
            helper.SendMail(obj.DeliveryEmail, "[VinFruits] THÔNG BÁO HỦY ĐƠN HÀNG", "Hủy đơn hàng thành công");
            Notification.set_flash("Hủy đơn thành công!", "success");
            return RedirectToAction("Order", "Account");
        }
    }
}