using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITIEntities.Data
{
    internal class ITIContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=YOUSSEF\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(s =>
            {
                s.HasKey(s => new { s.StudentId, s.CrsNo });
            });
            modelBuilder.Entity<Course>(s =>
            {
                s.HasKey(s => s.CrsId);
                s.Property(s => s.CrsId)
                .ValueGeneratedNever();

                s.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);


            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
