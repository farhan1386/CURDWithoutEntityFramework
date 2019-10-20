using CURDWithoutEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.GetEmployees().Find(e => e.Id == id);
            if (employee==null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
    }
}