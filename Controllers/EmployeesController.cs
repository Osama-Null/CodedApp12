using CodedApp12.Data;
using CodedApp12.Models;
using CodedApp12.Migrations;
using CodedApp12.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodedApp12.Controllers
{
    public class EmployeesController : Controller
    {
        private CodedDbContext _db;
        public EmployeesController(CodedDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Employees);
        }

        [HttpPost]
        public IActionResult AddEmp(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Depts = new SelectList(_db.Departments, "Id", "Name");
                return RedirectToAction("AddEmployee", "Products");
                // You must specify the controller and the action because the [GET] add emplyee view is in another controller (not in the current controller "Employees")
            }  //  And you have to use RedirectToAction bc same as the reason before!

            Employee employee = new Employee() // Mapping to cook the models in right shape to pass it to employee
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Salary = model.Salary,
                HDate = model.HDate,
                DepartmentId = model.DepartmentId,
            };

            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
