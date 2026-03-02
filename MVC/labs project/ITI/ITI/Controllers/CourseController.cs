using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        IEntityRepo<Course> repo = new CourseRepo();
        public IActionResult Index() => View(repo.GetAll());
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (!ModelState.IsValid) return View(course);
            repo.Add(course);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var model = repo.GetById(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Course course, int id)
        {
            course.CrsId = id;
            repo.Update(course);
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