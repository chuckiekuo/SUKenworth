using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUKenworth.Controllers.Backend;
using SUKenworth.Models.TestDataModels;

namespace SUKenworth.Controllers
{
    public class HomeController : Controller
    {
        private Backend.DataController myBackend;

        public ActionResult SetDatabase()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetDatabase([Bind(Include =

            "Name"+

            "")] DatabaseModel database)
        {
            // TO-DO: Error Checking for Connection
            if(database.Name.Length > 0)
            {
                 myBackend = new Backend.DataController(database.Name);
            }
            return RedirectToAction("SetDatabase");
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


        // Takes in errorCode and returns custom Error page
        public ActionResult Error(int errorCode = 0)
        {

            // instantiates new error object embedded with custom error code
            var error = new Models.ErrorModel
            {
                MErrorCode = errorCode
            };

            return View("Error", error);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}