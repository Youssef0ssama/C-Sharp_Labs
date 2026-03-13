using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<Product> GetAllWithCategory() => _context.Products.Include(p => p.Category).ToList();

        public Product GetByIdWithCategory(int id) => _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);

        public void Add(Product product) => _context.Products.Add(product);
        public void Update(Product product) => _context.Products.Update(product);
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) _context.Products.Remove(product);
        }
        public void Save() => _context.SaveChanges();
    }
}