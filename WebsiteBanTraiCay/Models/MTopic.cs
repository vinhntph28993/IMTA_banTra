namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


    [Table("Topic")]
    public class MTopic
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? ParentID { get; set; }
        public int Order { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }

        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
    }
}