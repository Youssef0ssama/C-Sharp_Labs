using ITI.Models.ViewModel;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ITI.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class StudentController : Controller
    {
        IEntityRepo<Student> stdRepo = new StudentRepo();
        IEntityRepo<Department> deptRepo = new DepartmentRepo();
        public IActionResult Index()
        {
            return View(stdRepo.GetAll());
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.depts = deptRepo.GetAll();
            return View();
        }
        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Create(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.depts = deptRepo.GetAll();
                return View(student);
            }
            Student std = new Student
            {
                Name = student.Name,
                Age = student.Age,
                Deptno = student.DeptNo
            };
            stdRepo.Add(std);
            return RedirectToAction("Index");
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var model = stdRepo.GetById(id.Value);
            if (model == null) return NotFound();
            ViewBag.depts = deptRepo.GetAll();
            StudentVM vm = new StudentVM { Id = model.Id, Name = model.Name, Age = model.Age, DeptNo = model.Deptno };
            return View(vm);
        }
        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Edit(StudentVM student, int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.depts = deptRepo.GetAll();
                return View(student);
            }
            Student std = new Student { Id = id, Name = student.Name, Age = student.Age, Deptno = student.DeptNo };
            stdRepo.Update(std);
            return RedirectToAction(nameof(Index));
        }
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var model = stdRepo.GetById(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null) return BadRequest();
            stdRepo.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
            var model = stdRepo.GetById(id.Value);
            return View(model);
        }
    }
}
