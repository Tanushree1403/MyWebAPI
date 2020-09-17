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
            emp = _db.GetAllEmployees();
            return View(emp);
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