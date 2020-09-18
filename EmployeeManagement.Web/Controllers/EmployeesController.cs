using EmployeeManagement.Web.DataService;
using EmployeeManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeDB _db;
        public HomeController(IEmployeeDB db)
        {
            this._db = db;
        }

        public ActionResult Index()
        {
            List<Employees> emp = new List<Employees>();
            emp = _db.GetAllEmployees(true);
            return View(emp);
        }

        [HttpGet]
        public ActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployees(Employees emp)
        {
            try
            {
                _db.AddEmployees(emp);
                ViewBag.Message = "Employee details added successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error!!";
                //return RedirectToAction();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}