using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> GetAll() => _context.Categories.ToList();
        public Category GetById(int id) => _context.Categories.Find(id);
        public void Add(Category category) => _context.Categories.Add(category);
        public void Update(Category category) => _context.Categories.Update(category);
        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null) _context.Categories.Remove(category);
        }
        public void Save() => _context.SaveChanges();
    }
}