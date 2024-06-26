namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


    [Table("Order")]
    public class MOrder
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Code { get; set; }
        public int UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ExportDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryEmail { get; set; }
        public int? Status { get; set; }
        public bool IsPayment { get; set; }
        public int? Trash { get; set; }
        public DateTime? Updated_at { get; set; }
        public int? Updated_by { get; set; }
    }
}