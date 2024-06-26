namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using System.Web;


    [Table("Contact")]
    public class MContact
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Flag { get; set; }
        public string Reply { get; set; }

        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
    }
}