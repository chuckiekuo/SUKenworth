using SUKenworth.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtensionMethods;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace SUKenworth.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Admin
        public ActionResult Index(string id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            string[] newId = id.Split('0');
            string finalId = newId[0] + "." + newId[4];

            var user = UserManager.FindByName(finalId);

            if (user.AdminUser == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home/Index");
            }

        }

        public ActionResult ListUsers()
        {
   
            return View(_userManager.Users);
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