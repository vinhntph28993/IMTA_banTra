using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanTraiCay.Models
{
    public class ProductTop
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}