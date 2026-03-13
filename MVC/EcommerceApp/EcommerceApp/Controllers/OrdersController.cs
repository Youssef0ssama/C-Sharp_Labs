using EcommerceApp.Data;
using EcommerceApp.Helpers;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceApp.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObject<List<CartItemVM>>("Cart");
            if (cart == null || !cart.Any()) return RedirectToAction("Index", "Cart");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userAddresses = _context.Addresses.Where(a => a.UserId == userId).ToList();
            ViewBag.Addresses = new SelectList(userAddresses, "AddressId", "Street");

            var vm = new CheckoutVM { CartItems = cart };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutVM model)
        {
            var cart = HttpContext.Session.GetObject<List<CartItemVM>>("Cart");
            if (cart == null || !cart.Any()) return RedirectToAction("Index", "Cart");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                var userAddresses = _context.Addresses.Where(a => a.UserId == userId).ToList();
                ViewBag.Addresses = new SelectList(userAddresses, "AddressId", "Street");
                model.CartItems = cart;
                return View(model);
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (var item in cart)
                {
                    var product = _context.Products.Find(item.ProductId);
                    if (product.StockQuantity < item.Quantity)
                    {
                        throw new Exception($"Not enough stock for {product.Name}");
                    }

                    product.StockQuantity -= item.Quantity;
                    _context.Products.Update(product);
                }

                var order = new Order
                {
                    UserId = userId,
                    ShippingAddressId = model.SelectedAddressId,
                    OrderNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                    Status = 0, // 0 = Pending
                    TotalAmount = cart.Sum(c => c.LineTotal),
                    OrderDate = DateTime.Now
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var item in cart)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        UnitPrice = item.Price,
                        Quantity = item.Quantity,
                        LineTotal = item.LineTotal
                    };
                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();

                transaction.Commit();

                HttpContext.Session.Remove("Cart");
                return RedirectToAction("Index", "Orders");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ModelState.AddModelError("", ex.Message);

                var userAddresses = _context.Addresses.Where(a => a.UserId == userId).ToList();
                ViewBag.Addresses = new SelectList(userAddresses, "AddressId", "Street");
                model.CartItems = cart;

                return View(model);
            }
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IQueryable<Order> ordersQuery = _context.Orders.Include(o => o.ApplicationUser);

            if (!User.IsInRole("Admin"))
            {
                ordersQuery = ordersQuery.Where(o => o.UserId == userId);
            }

            var orders = ordersQuery.OrderByDescending(o => o.OrderDate).ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (order.UserId != userId && !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            var vm = new OrderDetailsVM
            {
                OrderHeader = order,
                OrderItems = order.OrderItems
            };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int orderId, int newStatus)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}