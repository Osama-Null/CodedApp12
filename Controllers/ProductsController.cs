using Microsoft.AspNetCore.Mvc;
using CodedApp12.Data;
using System.Drawing;
using CodedApp12.Models;
using CodedApp12.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodedApp12.Controllers
{
    public class ProductsController : Controller
    {
        private CodedDbContext _db;
        public ProductsController(CodedDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id == null) // If number is not in db, it will return him index
            {
                return View("Index");
            }

            var product = _db.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(product);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            return View(_db.Products);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            return View(_db.Products);
        }
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            ProductEmployeeViewModel model = new ProductEmployeeViewModel()
            {
                Employees = _db.Employees.Include(x=>x.Department).OrderByDescending(model => model.Id).ToList(),
                Products = _db.Products.ToList()
            };

            return View(model);
        }
        public IActionResult AddEmployee()
        {
            ViewBag.Depts = new SelectList(_db.Departments, "Id", "Name");
            return View();
        } // The [POST] is in Employees controller
        public IActionResult DetailsEmployee(int? id)
        {
            if (id == null) // If number is not in db, it will return him index
            {
                return View("Index");
            }

            var product = _db.Employees.Find(id);
            if (product == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(product);
        }
        public IActionResult Mydata()
        {
            ViewBag.AllEmployees = _db.Employees;
            ViewBag.AllProducts = _db.Products;
            return View();
        }
    }
}
