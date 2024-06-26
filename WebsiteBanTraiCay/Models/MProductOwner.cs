using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanTraiCay.Models
{
    [Table("ProductOwner")]
    public class MProductOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Longiude { get; set; }
        public string Latitude { get; set; }
        public DateTime Created_at {get;set;}
        public int Created_by {get;set;}
        public DateTime Updated_at {get;set;}
        public int Updated_by { get; set; }
        public int Status { get; set; }
    }
}