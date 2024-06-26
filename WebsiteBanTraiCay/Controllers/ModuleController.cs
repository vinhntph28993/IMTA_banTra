using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanTraiCay.Models;

namespace WebsiteBanTraiCay.Controllers
{
    public class ModuleController : Controller
    {
        private ConnectDbContext db = new ConnectDbContext();
        // GET: Module
        public ActionResult Categories()
        {
            return View("_Categories", db.Categorys.Where(m=> m.Status == 1).ToList());
        }
        public ActionResult SlideShow()
        {
            // Position = 1 = SlideShow
            return View("_SlideShow", db.Sliders.Where(m => m.Status == 1 && m.Position == "1").ToList());
        }
        public ActionResult ConfigHead()
        {
            ViewBag.Configs = db.Configs.First();  
            return View();
        }
        public ActionResult ConfigAnalytic()
        {
            ViewBag.Configs = db.Configs.First();
            return View();
        }
        
        public ActionResult Header()
        {
            ViewBag.Promotion = db.Posts.Where(m => m.Status == 1 && m.Type == "post" && m.TopicID == 22).OrderByDescending(m => m.Created_at).Take(3).ToList();
            ViewBag.Configs = db.Configs.First();
            ViewBag.APITalkTo = db.Configs.First();
            var list = db.Categorys.Where(m => m.Status == 1).ToList();
            return View("_Header", list);
        }
        public ActionResult Footer()
        {
            //ViewBag.Title = db.Menus.Where(m => m.Status == 1 && m.Positon == "footer" && m.ParentID == 0).Take(2).ToList();
            ViewBag.Config = db.Configs.Take(1).ToList();
            ViewBag.Configs =  db.Configs.First();
            ViewBag.Page = db.Posts.Where(m => m.Status == 1 && m.Type == "page"&&m.Location== "customer").ToList();
            return View("_Footer", db.Menus.Where(m => m.Status == 1 && m.Positon == "footer").ToList());
        }
        public ActionResult HomeSlideShow()
        {
            ViewBag.Slider = db.Sliders.Where(m => m.Status == 1 && m.Position == "2").OrderByDescending(m => m.Created_at).Take(2).ToList();
            return View("_HomeSlideShow", db.Posts.Where(m => m.Status == 1 && m.Type == "post" && m.Position == "slider").ToList());
        }
        public ActionResult Popu()
        {
            return View("_Popu");
        }
        public ActionResult ListCategory()
        {
            var list = db.Categorys.Where(m => m.Status == 1 && m.ParentID == 0).ToList();
            return View("_ListCategory", list);
        }
        public ActionResult NewsHome()
        {
            return View("_NewsHome", db.Posts.Where(m => m.Status == 1 && m.Type == "post" && m.Position == "default").OrderByDescending(m => m.Created_at).Take(5).ToList());
        }
        public ActionResult Login()
        {
            return View("_Login");
        }
        public ActionResult MainMenu()
        {
            return View("_MainMenu", db.Menus.Where(m => m.Status == 1 && m.Positon == "header").ToList());
        }
        // partial page load with ajax
        public ActionResult MiTC()
        {
            return View("_MiTC");
        }
        public ActionResult ICart()
        {
            return View("_ICart");
        }
        public ActionResult ListPage()
        {
           
            return View("_ListPage", db.Posts.Where(m => m.Status == 1 && m.Type == "page" &&m.Location== "connect_footer").ToList());
        }
        public ActionResult EventHeader()
        {
            ViewBag.Eventnews = db.Event.Where(m => m.Status == 1).Take(2).OrderByDescending(m => m.Created_At).ToList();
            var list = db.Event.Where(m => m.Status == 1).Take(1).OrderBy(m => m.Created_At);
            return View("EventHeader", list);
        }
    }
}