using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SUKenworth.Controllers;

namespace ExtensionMethods
{
    public static class IdentityExtensions
    {

        public static bool GetIsAdminUser(this IIdentity identity)
        {
            if (identity == null)
            {
                return false;
            }

            // return new ManageController().IsUserAdminUser(userId);

            var claim = ((ClaimsIdentity)identity).FindFirst("AdminUser");
            // Test for null to avoid issues during local testing

            if (claim == null)
            {
                return false;
            }

            if (claim.Value.Equals("True"))
            {
                return true;
            }

            return false;
        }
    }
}