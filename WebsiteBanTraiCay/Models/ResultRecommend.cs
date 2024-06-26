using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanTraiCay.Models
{
    public class ResultRecommend
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Longiude { get; set; }
        public string Latitude { get; set; }

        public float Value { get; set; }

        public int Distance { get; set; }
    }
}