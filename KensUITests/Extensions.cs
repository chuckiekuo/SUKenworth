using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace KensUITests
{
    public class Extensions
    {
        //IMPORTANT:::be sure these file locations are correct for your machine
        //always be sure the website is running before attempting to test
        //URL of the homepage
        public const string BaseUrl = "http://localhost:50298/";

        //file location of the chrome driver
        //public const string ChromeDriverLocation = "C:/Users/oslandt/Desktop/KenworthTeamsCommonProject/SUKenworth/KensUITests";
        public const string ChromeDriverLocation = "C:/Users/The Salty Spitoon/Desktop/KenworthCommonFeatures/SUKenworth/KensUITests";

        //location to store screenshots in
        private const string ScreenshotLocation = "C:/Users/oslandt/Desktop/Screenshots";


        //log in details for nonadmin valid
        public const string ValidEmailNotAdmin1 = "userTest@gmail.com";
        public const string ValidPasswordNotAdmin1 = "123456";

        //log in details for admin valid
        public const string ValidEmailAdmin1 = "testOMGTEST@gmail.com";
        public const string ValidPasswordAdmin1 = "123456";


        //log in details for nonadmin invalid


        //log in details for admin invalid



        //log in details for nonadmin to be valid registered 
        public const string ValidEmailNotAdmin2 = "UITestUser@paccar.com";
        public const string ValidPasswordNotAdmin2 = "123456";

        //log in details for admin to be valid registered
        public const string ValidEmailAdmin2 = "UITestAdmin@paccar.com";
        public const string ValidPasswordAdmin2 = "123456";

        //log in details for nonadmin users to be invalid regsitered


        //log in details for admin users to be invalid registered


        //maximum time to wait for a browser page to load
        public const int MaxWaitTime = 20;


        //id tags to search for
        public const string LoginEmailInputBoxIdTag = "Email";
        public const string LoginPasswordInputBoxIdTag = "Password";
        public const string LoginSubmitButtonIdTag = "LogInSubmit";
        public const string LogoutIdTag = "LogOffSubmit";


        //for fetching the current date and time in a format that can be stored as a file name
        public static string CurrentDateTimeFileStringFormat()
        {
            string originalFormat = DateTime.Now.ToString("t");

            string finalFormat = originalFormat.Replace(":", "-");

            return finalFormat;
        }

        //used only for extreme error checking
        public static void TakeScreenshot(IWebDriver driver)
        {
            //save a screenshot of the result
            try
            {
                //take the screenshot
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                //create the name of the sceenshot
                string ssName = Extensions.ScreenshotLocation + Extensions.CurrentDateTimeFileStringFormat() + ".jpg";

                //store the screenshot
                ss.SaveAsFile(ssName, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //use only for extreme error checking
        public static void TakeScreenshot(IWebDriver driver, string funcName)
        {
            //save a screenshot of the result
            try
            {
                //take the screenshot
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                //create the name of the sceenshot
                string ssName = Extensions.ScreenshotLocation + funcName + Extensions.CurrentDateTimeFileStringFormat() + ".jpg";

                //store the screenshot
                ss.SaveAsFile(ssName, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static bool ValidatePageTransition(IWebDriver driver, string controller, string action, string data = null)
        {
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-"+controller+"-Done"));
                driver.FindElement(By.Id("View-"+action+"-Done"));

            return true;
        }

        public static bool NavigateToPage(IWebDriver driver, string controller, string action, string data = null)
        {

            //navigate to the kenworth page
            driver.Navigate().GoToUrl(Extensions.BaseUrl+"/"+controller+"/"+action+"/"+data);
            
            //check that page is the right page
            ValidatePageTransition(driver, controller, action);

            return true;
        }

        public static void LogIn(IWebDriver currentDriver, string username, string password)
        {
            //find the email box to input username info
            IWebElement emailBox = currentDriver.FindElement(By.Id(LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(username);

            //find the password box to input password info  
            IWebElement passwordBox = currentDriver.FindElement(By.Id(LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(password);

            //submit
            currentDriver.FindElement(By.Id(LoginSubmitButtonIdTag)).Click();
        }

        public static void LogOut(IWebDriver currentDriver)
        {
            currentDriver.FindElement(By.Id(LogoutIdTag)).Click(); // Click logout button
        }
    }
}
