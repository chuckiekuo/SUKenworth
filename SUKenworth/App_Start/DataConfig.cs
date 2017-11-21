using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUKenworth.App_Start
{
    public static class DataConfig
    {
        public const string TestDatabase1 = "Server=tcp:kenworthprojects.database.windows.net,1433;Initial Catalog=KenworthProjectsTest;Persist Security Info=False;User ID=su_admin;Password=Kenworth!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public const string TestDatabase2 = "Server=tcp:kenworthprojects.database.windows.net,1433;Initial Catalog=KenworthProjectsTest2;Persist Security Info=False;User ID=su_admin;Password=Kenworth!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}