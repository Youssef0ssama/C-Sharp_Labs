using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}