using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace EcommerceApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public ICollection<Address> Addresses { get; set; }
        [InverseProperty("ApplicationUser")]
        public ICollection<Order> Orders { get; set; }
    }
}