namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using System.Web;


    [Table("OrderDetail")]
    public class MOrderDetail
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }

    }
}