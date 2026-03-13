using EcommerceApp.Models;

namespace EcommerceApp.ViewModels
{
    public class OrderDetailsVM
    {
        public Order OrderHeader { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}