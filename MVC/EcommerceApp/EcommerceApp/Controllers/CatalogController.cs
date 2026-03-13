using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Repositories;
using EcommerceApp.ViewModels;

namespace EcommerceApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public CatalogController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index(int? categoryId, string q, int page = 1)
        {
            int pageSize = 6;
            var products = _productRepo.GetAllWithCategory().Where(p => p.IsActive);

            if (categoryId.HasValue)
                products = products.Where(p => p.CategoryId == categoryId.Value);

            if (!string.IsNullOrEmpty(q))
                products = products.Where(p => p.Name.Contains(q, StringComparison.OrdinalIgnoreCase));

            int totalItems = products.Count();

            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var vm = new ProductListVM
            {
                Products = pagedProducts,
                Categories = _categoryRepo.GetAll(),
                SelectedCategoryId = categoryId,
                SearchQuery = q,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepo.GetByIdWithCategory(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}