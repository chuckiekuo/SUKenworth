using SUKenworth.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SUKenworth.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public string[] Getuserinfo(RegisterViewModel registerViewModel)
        {
            /*retrieve a list of users and their info and then
             *return that list to the view*/
            /*string h; is here just so that the project
             *can compile, will edit later*/
            string[] h=new string[5];
            return h;
        }
    }
}