using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace EcommerceApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [ForeignKey("ShippingAddress")]
        public int ShippingAddressId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        public int Status { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Address ShippingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}