namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using System.Web;


    [Table("Event")]
    public class MEvent
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Detail { get; set; }
        public int? Status { get; set; }
        public string Type { get; set; }
        public DateTime Created_At { get; set; }
    }
}