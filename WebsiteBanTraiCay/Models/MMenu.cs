namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using System.Web;


    [Table("Menu")]
    public class MMenu
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string Link { get; set; }
        public int? TableID { get; set; }
        public int? ParentID { get; set; }
        public int Orders { get; set; }
        [Required]
        public string Positon { get; set; }

        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
    }
}