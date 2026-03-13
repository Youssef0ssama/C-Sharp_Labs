using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public bool IsDefault { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}