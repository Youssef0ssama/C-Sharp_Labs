using ITIEntities.Repo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITI.Controllers
{
    public class AccountController : Controller
    {
        UserRepo repo = new UserRepo();
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Login(string userName, string password)
        {
            var user = repo.FindAll(u => u.UserName == userName).FirstOrDefault();
            if (user == null)
                return View();
            if (user.PasswordHash != password)
                return View();

            var roleName = user.Role?.Name ?? "User";
            var claims = new[] { new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Role, roleName) };
            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(principal);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}