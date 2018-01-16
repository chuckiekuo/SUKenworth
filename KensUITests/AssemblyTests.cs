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
        public static IWebDriver CurrentDriver = new ChromeDriver(Extensions.ChromeDriverLocation);

        public static ChromeOptions Options = new ChromeOptions();

        public static string LocalUrl = Extensions.BaseUrl;
        //public static string LiveUrl = "";
        public static string UrlPrefix = LocalUrl;

        public static WebDriverWait Wait = new WebDriverWait(CurrentDriver, new TimeSpan(0, 0, 5));
        public static WebDriverWait Wait20 = new WebDriverWait(CurrentDriver, new TimeSpan(0, 0, 20));

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            //here you should call a login in test so that when tests are "initialized" they will be logged in
            //shoulld be passing in the driver as a parameter
            //this means that the current tests must be rewritten to allow parameters
            //this would allow future tests to not haave to have code in them that repeats the login processes, just call this assembly function

            //set implicit wait for driver
            CurrentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

            
        }

        [TestInitialize]
        public static void AssemblyTestInitialize()
        {
            //navigate to home page
            Extensions.NavigateToPage(CurrentDriver, "Home", "Index");
        }

        [TestCleanup]
        public static void AssemblyTestCleanup()
        {
            //be sure no profiles are signed in
            Extensions.LogOut(CurrentDriver);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            
            //finally, quit the current driver
            CurrentDriver.Quit();
        }
    }
}
