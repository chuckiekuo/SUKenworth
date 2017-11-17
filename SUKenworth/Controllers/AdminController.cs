using SUKenworth.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtensionMethods;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

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

            if (User.Identity.GetIsAdminUser())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult ListUsers()
        {
            List<ApplicationUser> myList = UserManager.Users.ToList<ApplicationUser>();
            List<string> usernames = new List<string>();

            for (int i = 0; i < myList.Count(); i++)
            {
                usernames.Add(myList[i].Email);
            }

            return View(usernames);
        }

        public async Task<ActionResult> ToggleAdmin(string id)
        {
            // TODO: this code is not working, It should remove the claim, but the remove is not reflected in the DB.  Need to investigate how to have the remove save to the DB...
            if (User.Identity.GetIsAdminUser())
            {
                await UserManager.RemoveClaimAsync(id, new Claim("AdminUser", "True"));
            }
            else
            {
                await UserManager.AddClaimAsync(id, new Claim("AdminUser", "True"));
            }

            return RedirectToAction("Index","Manage", new { });

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