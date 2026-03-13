using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.ViewModels
{
    public class CheckoutVM
    {
        [Required(ErrorMessage = "Please select a shipping address.")]
        public int SelectedAddressId { get; set; }
        public List<CartItemVM> CartItems { get; set; } = new List<CartItemVM>();
        public decimal TotalAmount => CartItems?.Sum(c => c.LineTotal) ?? 0;
    }
}