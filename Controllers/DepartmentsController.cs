using CodedApp12.Data;
using CodedApp12.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodedApp12.Controllers
{
    public class DepartmentsController : Controller
    {
        private CodedDbContext _db;
        public DepartmentsController(CodedDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Departments);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            _db.Departments.Add(department);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
