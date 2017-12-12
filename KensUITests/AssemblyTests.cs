using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace KensUITests
{
    [TestClass]
    public class AssemblyTests
    {
        public static IWebDriver CurrentDriver = new ChromeDriver();

        public static ChromeOptions Options = new ChromeOptions();

        public static string LocalUrl = "http://localhost:50298/";
        //public static string LiveUrl = "";
        //public static string UrlPrefix = LocalUrl;

        public static WebDriverWait Wait = new WebDriverWait(CurrentDriver, new TimeSpan(0, 0, 5));
        public static WebDriverWait Wait20 = new WebDriverWait(CurrentDriver, new TimeSpan(0, 0, 20));

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //here you should call a login in test so that when tests are "initialized" they will be logged in
            //shoulld be passing in the driver as a parameter
            //this means that the current tests must be rewritten to allow parameters
            //this would allow future tests to not haave to have code in them that repeats the login processes, just call this assembly function

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //should have a logout method here so the current driver will log out
            //finally, quit the current driver
        }
    }
}
