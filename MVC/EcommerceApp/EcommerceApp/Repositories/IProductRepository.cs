using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllWithCategory();
        Product GetByIdWithCategory(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();
    }
}