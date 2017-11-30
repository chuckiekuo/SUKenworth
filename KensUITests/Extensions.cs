using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KensUITests
{
    public class Extensions
    {
        //IMPORTANT:::be sure these file locations are correct for your machine
        //always be sure the website is running before attempting to test
        //URL of the homepage
        public const string Homepage = "http://localhost:50298/";

        //file location of the chrome driver
        public const string ChromeDriverLocation = "C:/Users/oslandt/Desktop/KenworthTeamsCommonProject/SUKenworth/KensUITests";

        //location to store screenshots in
        public const string ScreenshotLocation = "C:/Users/oslandt/Desktop/Screenshots";



        //log in details for admin user
        public const string ValidEmailAdmin1 = "testOMGTEST@gmail.com";
        public const string ValidPasswordAdmin1 = "123456";

        //log in details for nonadmin user
        public const string ValidEmailNotAdmin1 = "userTest@gmail.com";
        public const string ValidPasswordNotAdmin1 = "123456";

        //log in details for user to be registered correctly
        public const string ValidEmailNotAdmin2 = "UITestUser@paccar.com";
        public const string ValidPasswordNotAdmin2 = "123456";


        //maximum time to wait for a browser page to load
        public const int MaxWaitTime = 20;



        //for fetching the current date and time in a format that can be stored as a file name
        public static string CurrentDateTimeFileStringFormat()
        {
            string originalFormat = DateTime.Now.ToString("t");

            string finalFormat = originalFormat.Replace(":", "-");

            return finalFormat;
        }
    }
}
