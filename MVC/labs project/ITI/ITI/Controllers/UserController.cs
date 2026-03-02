using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        UserRepo repo = new UserRepo();
        IEntityRepo<Role> roleRepo = new RoleRepo();
        public IActionResult Index() => View(repo.GetAll());
        public IActionResult Create()
        {
            ViewBag.roles = roleRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.roles = roleRepo.GetAll();
                return View(user);
            }
            repo.Add(user);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var model = repo.GetById(id.Value);
            if (model == null) return NotFound();
            ViewBag.roles = roleRepo.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(User user, int id)
        {
            user.Id = id;
            repo.Update(user);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var model = repo.GetById(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null) return BadRequest();
            repo.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
            var model = repo.GetById(id.Value);
            return View(model);
        }
    }
}