namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


    [Table("Slider")]
    public class MSlider
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public int Orders { get; set; }

        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
    }
}