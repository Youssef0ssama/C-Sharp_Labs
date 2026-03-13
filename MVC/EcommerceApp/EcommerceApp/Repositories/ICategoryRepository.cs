using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        void Save();
    }
}