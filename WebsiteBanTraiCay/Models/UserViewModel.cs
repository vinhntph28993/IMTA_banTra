using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanTraiCay.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int Access { get; set; }
        public string GroupName { get; set; }
        public int Status { get; set; }
        public int PayTotal { get; set; }
    }
}