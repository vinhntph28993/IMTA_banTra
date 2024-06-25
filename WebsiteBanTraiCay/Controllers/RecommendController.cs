using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanTraiCay.Models;

namespace WebsiteBanTraiCay.Controllers
{
    public class RecommendController : Controller
    {
        private ConnectDbContext db = new ConnectDbContext();
        // GET: Address
        public ActionResult Index(string mes)
        {
            ViewBag.Location = db.ProductOwners.ToList();
            return View();
        }
        private List<MProductOwner> GetList()
        {
            return db.ProductOwners.ToList();
        }

        [HttpGet]
        public ActionResult GetAddress()
        {
            ViewBag.Location = db.ProductOwners.ToList();          
            return View();
        }

        [HttpPost]
        public ActionResult GetAddress(FormCollection form)
        {
            string longTi = form["longTi"];
            string lat = form["lat"];
            var data = KNearestNeighbor(longTi,lat);
            ViewBag.data = data;
            ViewBag.Mes = 1;
            return View();
        }

        private float CalcDistancs(string longTiA,string latA, string longTiB, string latB)
        {
            float distance = (float)Math.Pow(float.Parse(longTiA) - float.Parse(longTiB), 2) + (float)Math.Pow(float.Parse(latA) - float.Parse(latB), 2);         
            return (float)Math.Sqrt(distance);
        }

        private List<ResultRecommend> KNearestNeighbor(string longTi, string lat)
        {
            var listBranch = GetList();
            var distances = new List<ResultRecommend>();
            var resultRecommend = new ResultRecommend();
            for (int i = 0; i < listBranch.Count; i++)
            {
                resultRecommend = new ResultRecommend
                {
                    Id = listBranch[i].Id,
                    Name = listBranch[i].Name,
                    Longiude = listBranch[i].Longiude,
                    Latitude = listBranch[i].Latitude,
                    Value = CalcDistancs(longTi, lat, listBranch[i].Longiude, listBranch[i].Latitude),
                    Distance = Distance(lat, longTi, listBranch[i].Latitude,listBranch[i].Longiude)
                };
                distances.Add(resultRecommend);
            }
            List<ResultRecommend> resultSort = distances.OrderBy(x => x.Value).ToList();
            return resultSort;
        }

        private int Distance(string lat1, string lon1, string lat2, string lon2)
        {
            var p = 0.017453292519943295;    // Math.PI / 180
            var a = 0.5 - Math.Cos((float.Parse(lat2) - float.Parse(lat1)) * p) / 2 +
                    Math.Cos(float.Parse(lat1) * p) * Math.Cos(float.Parse(lat2) * p) *
                    (1 - Math.Cos((float.Parse(lon2) - float.Parse(lon1)) * p)) / 2;

            return (int)(12742 * Math.Asin(Math.Sqrt(a))); // 2 * R; R = 6371 km
        }     
    }
}