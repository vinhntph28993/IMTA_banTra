﻿namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class ProductCategory
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public int ProductStatus { get; set; }
        public int ProductDiscount { get; set; }
        public string CategoryName { get; set; }
    }
}