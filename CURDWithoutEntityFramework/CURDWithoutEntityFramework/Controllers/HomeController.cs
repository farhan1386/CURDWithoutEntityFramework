using CURDWithoutEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDWithoutEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataAccessLayer db = new DataAccessLayer();

        public ActionResult Index()
        {
            var employee = db.GetEmployees();
            return View(employee);
        }
    }
}