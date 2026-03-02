using ITIEntities;
using ITIEntities.Repo;
using System.Linq;

namespace ITI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();

            // Seed initial role and admin user if not present (simple plaintext password to match project style)
            try
            {
                var roleRepo = new RoleRepo();
                var userRepo = new UserRepo();
                if (!roleRepo.GetAll().Any(r => r.Name == "Admin"))
                {
                    roleRepo.Add(new Role { Name = "Admin" });
                }
                if (!userRepo.FindAll(u => u.UserName == "admin").Any())
                {
                    var adminRole = roleRepo.FindAll(r => r.Name == "Admin").FirstOrDefault();
                    if (adminRole != null)
                    {
                        userRepo.Add(new User { UserName = "admin", PasswordHash = "admin", RoleId = adminRole.Id });
                    }
                }
            }
            catch
            {
                // ignore seeding errors (DB might not be created yet)
            }

            app.Run();
        }
    }
}
