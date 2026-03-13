using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using EcommerceApp.Models;
using EcommerceApp.Repositories;

namespace EcommerceApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductsController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index() => View(_productRepo.GetAllWithCategory());

        public IActionResult Details(int id)
        {
            var product = _productRepo.GetByIdWithCategory(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryRepo.GetAll(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Add(product);
                _productRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(_categoryRepo.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _productRepo.GetByIdWithCategory(id);
            if (product == null) return NotFound();

            ViewBag.CategoryId = new SelectList(_categoryRepo.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();

            if (ModelState.IsValid)
            {
                _productRepo.Update(product);
                _productRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(_categoryRepo.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepo.GetByIdWithCategory(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepo.Delete(id);
            _productRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}