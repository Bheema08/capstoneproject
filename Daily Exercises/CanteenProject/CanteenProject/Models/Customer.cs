using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenProject.Models
{
    public class Customer
    {
        [Key]
        [Column("custId")]
        public int custId {  get; set; }
        [Column("custName")]
        public string ? custName { get; set; }
        [Column("custUserName")]
        public string? custUserName { get; set; }
        [Column("custPassword")]
        public string? custPassword { get; set; }
        [Column("email")]
        public string? email { get; set; }
        [Column("mobileNo")]
        public string? mobileNo { get; set; }
        [Column("city")]
        public string? city { get; set; }
        [Column("state")]
        public string? state {  get; set; }
    }
}
