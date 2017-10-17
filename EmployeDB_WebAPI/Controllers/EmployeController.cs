using EmployesDB;
using EmployesDB.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeDB_WebAPI.Controllers
{
    public class EmployeController : Controller
    {
       

        // GET: Employe
        public ActionResult Index()
        {
           return View();
        }

        public PartialViewResult AddEmploye()
        {
            return PartialView();
        }

        public PartialViewResult DelEmploye()
        {
            return PartialView();
        }

        public PartialViewResult EditEmploye()
        {
            return PartialView();
        }

        public PartialViewResult ViewStatEmploye()
        {
            return PartialView();
        }


        public PartialViewResult OptionDBEmploye()
        {
            return PartialView();
        }
    }
}
