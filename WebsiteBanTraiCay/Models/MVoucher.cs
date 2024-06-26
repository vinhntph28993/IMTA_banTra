namespace WebsiteBanTraiCay.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Voucher")]
    public class MVoucher
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string Name { get; set; }
        public int? Discount { get; set; }
        public int? Status { get; set; }
        public int? Quantity { get; set; }
        public string DateExpire { get; set; }
    }
}