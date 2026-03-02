using ITI.Models.ViewModel;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    public class StudentController : Controller
    {
        IEntityRepo<Student> stdRepo = new StudentRepo();
        IEntityRepo<Department> deptRepo = new DepartmentRepo();
        public IActionResult Index()
        {
            return View(stdRepo.GetAll());
        }
        public IActionResult Create()
        {
            ViewBag.depts = deptRepo.GetAll();
            return View();
        }
        [HttpPost]
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
    }
}
