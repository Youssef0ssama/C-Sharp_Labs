using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class StudentCourseController : Controller
    {
        StudentCourseRepo repo = new StudentCourseRepo();
        IEntityRepo<Student> studentRepo = new StudentRepo();
        IEntityRepo<Course> courseRepo = new CourseRepo();
        public IActionResult Index() => View(repo.GetAll());
        public IActionResult Create()
        {
            ViewBag.students = studentRepo.GetAll();
            ViewBag.courses = courseRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCourse sc)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.students = studentRepo.GetAll();
                ViewBag.courses = courseRepo.GetAll();
                return View(sc);
            }
            repo.Add(sc);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var model = repo.GetById(id.Value);
            if (model == null) return NotFound();
            ViewBag.students = studentRepo.GetAll();
            ViewBag.courses = courseRepo.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StudentCourse sc, int id)
        {
            sc.StudentId = id;
            repo.Update(sc);
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
    }
}