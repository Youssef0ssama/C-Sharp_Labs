using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        IEntityRepo<Department> deptRepo = new DepartmentRepo();
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
        public IActionResult Create(Department dept)
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
