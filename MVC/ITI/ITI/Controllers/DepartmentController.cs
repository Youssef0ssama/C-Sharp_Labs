using ITIEntities;
using ITIEntities.Repo;
using ITIEntities.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ITI.Controllers
{
    public class DepartmentController : Controller
    {
        IEntityRepo<Department> deptRepo = new DepartmentRepo();
        ITIContext db = new ITIContext();
        public IActionResult ShowCourses(int id)
        {
            var model = db.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DeptId == id);
            return View(model);
        }
        public IActionResult ManageDeptCourse(int id)
        {
            var model = db.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DeptId == id);
            var allcourses = db.Courses.ToList();
            var coursesNotInDept = allcourses.Except(model.Courses).ToList();
            ViewBag.coursesNotInDept = coursesNotInDept;
            return View(model);
        }

        [HttpPost]
        public IActionResult ManageDeptCourse(int id, int[] coursestoremove, int[] coursestoadd)
        {
            var dept = db.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DeptId == id);
            foreach (var courseId in coursestoremove)
            {
                Course c = dept.Courses.FirstOrDefault(c => c.CrsId == courseId);
                dept.Courses.Remove(c);
            }
            foreach (var item in coursestoadd)
            {
                Course c = db.Courses.FirstOrDefault(c => c.CrsId == item);
                dept.Courses.Add(c);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(ManageDeptCourse), new { id = id });
        }
        public ViewResult Index()
        {
            var model = deptRepo.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)//model binder
        {
            deptRepo.Add(dept);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = deptRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Department dept, int id)
        {
            dept.DeptId = id;
            deptRepo.Update(dept);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = deptRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return BadRequest();
            deptRepo.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = deptRepo.GetById(id.Value);
            return View(model);
        }

    }
}
