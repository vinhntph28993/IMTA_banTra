using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanTraiCay.Models
{
    [Table("Configs")]
    public class MConfig
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Tên Website hoặc tên chủ sở hữu")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập SĐT chính của Web")]
        public string Phone { get; set; }
        public string Phone_1 { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập cấu hình Gmail")]
        public string Gmail { get; set; }
        public string APITalkTo { get; set; }
        public string MessFacebook { get; set; }
        public string Zalo { get; set; }
        public string Analytic { get; set; }
        public string WebMasterTool { get; set; }
        public string Google_Maps { get; set; }
        public string LogoIconWeb { get; set; }
        public string LogoWeb { get; set; }
        public string Url { get; set; }
       /* public string Url_1 { get; set; }*/
    }
}
