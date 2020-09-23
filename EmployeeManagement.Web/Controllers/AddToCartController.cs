﻿using EmployeeManagement.Web.DataService;
using EmployeeManagement.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    public class AddToCartController : Controller
    {
        private IEmployeeDB _db;
        public AddToCartController(IEmployeeDB db)
        {
            this._db = db;
        }
        // GET: AddToCart
        [HttpGet]
        public ActionResult Index()
        {
            //Employees emp= _db.GetEmployeeById(empId);
            // //write to sessions:
            //;
            //(List<Employees>) Session["MyTeam"];
            return View((List<Employees>)Session["MyTeam"]);
        }
    }
}