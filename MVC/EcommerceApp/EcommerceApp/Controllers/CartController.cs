using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Data;
using EcommerceApp.Helpers;
using EcommerceApp.ViewModels;

namespace EcommerceApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItemVM>>("Cart") ?? new List<CartItemVM>();
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetObject<List<CartItemVM>>("Cart") ?? new List<CartItemVM>();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItemVM { ProductId = product.ProductId, ProductName = product.Name, Price = product.Price, Quantity = 1 });
            }

            HttpContext.Session.SetObject("Cart", cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetObject<List<CartItemVM>>("Cart") ?? new List<CartItemVM>();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    cart.Remove(item);
                }
                HttpContext.Session.SetObject("Cart", cart);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int productId)
        {
            var cart = HttpContext.Session.GetObject<List<CartItemVM>>("Cart") ?? new List<CartItemVM>();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.SetObject("Cart", cart);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}