using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EcommerceApp.Data;
using EcommerceApp.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    [Authorize]
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var addresses = _context.Addresses.Where(a => a.UserId == userId).ToList();
            return View(addresses);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("ApplicationUser");

            if (ModelState.IsValid)
            {
                address.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _context.Addresses.Add(address);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var address = _context.Addresses.FirstOrDefault(a => a.AddressId == id && a.UserId == userId);

            if (address == null) return NotFound();
            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var address = _context.Addresses.FirstOrDefault(a => a.AddressId == id && a.UserId == userId);

            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}