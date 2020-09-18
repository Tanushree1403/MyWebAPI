using EmployeeManagement.Web.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    public class SkillsController : Controller
    {
        private IEmployeeDB _db;
        public SkillsController(IEmployeeDB db)
        {
            this._db = db;
        }
        // GET: Skills
        public ActionResult GetSkills(string moniker)
        {
            return View(_db.GetEmployeeSkills(moniker));
        }
    }
}