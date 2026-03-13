using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<Product>().HasIndex(p => p.SKU).IsUnique();
            builder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique();

            builder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
            builder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
            builder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasPrecision(18, 2);
            builder.Entity<OrderItem>().Property(oi => oi.LineTotal).HasPrecision(18, 2);
        }
    }
}