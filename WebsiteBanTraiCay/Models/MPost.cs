namespace WebsiteBanTraiCay.Models
{
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using System.Web;


    [Table("Post")]
    public class MPost
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int TopicID { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public string Location { get; set; }

        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
    }
}