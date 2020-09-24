using EmployeeManagement.Web.DataService;
using EmployeeManagement.Web.Models;
using MyWebAPI.Filters;
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

        [OutputCache(CacheProfile = "cache10min")]
        [CustomExceptionFilter]
        public ActionResult Index()
        {
            List<Employees> emp = new List<Employees>();
            emp = _db.GetAllEmployees(true);
            return View(emp);
        }

        [HttpGet]
        [CustomExceptionFilter]
        public ActionResult GetEmployeeById(string moniker)
        {
            Employees emp = new Employees();
            emp = _db.GetEmployeeById(moniker);
            ViewBag.Employee = emp;
            return View();
        }


        [HttpGet]
        [CustomExceptionFilter]
        public ActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
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

        public ActionResult Error()
        {
            ViewBag.Message = "Your Error page.";

            return View();
        }

        [CustomExceptionFilter]
        public ActionResult AddCartToSession(string empId)
        {
            List<Employees> empList = new List<Employees>();
            Employees emp = _db.GetEmployeeById(empId);
            empList.Add(emp);
            //write to sessions:
            if (Session["MyTeam"] == null)
                Session["MyTeam"] = empList;
            else
            {
                empList = (List<Employees>)Session["MyTeam"];
                empList.Add(emp);
                Session["MyTeam"] = empList;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}