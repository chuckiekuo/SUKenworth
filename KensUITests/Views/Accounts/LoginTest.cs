using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Accounts
{
    [TestClass]
    public class LoginTest
    {
        private string _Controller = "Account";
        private string _Action = "Login";

        //use this as a method to do things such as a log in so that you don't have to repeat code
        //you can have different initialize functions
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Login_Valid_AdminLogin_Should_JumpToHomepage()
        {

            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))//<-Add your path
            {
                //set an implicit wait time before any search for an item fails
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

                NavigateToPage(driver, _Controller, _Action);

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

                //submit
                driver.FindElement(By.Id("LogInSubmit")).Click();

                //check that page is the right page
                //i dunno know what id's to look for, i cannot navigate to the page that naturally comes after a log in
                ValidatePageTransition(driver, "Home", "Index");

            }

        }


        [TestMethod]
        public void Login_Valid_NonAdminLogin_Should_JumpToHomepage()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))//<-Add your path
            {
                //set an implicit wait time before any search for an item fails
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

                NavigateToPage(driver, _Controller, _Action);


                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailNotAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordNotAdmin1);

                //submit
                driver.FindElement(By.Id("LogInSubmit")).Click();

                //check that page is the right page
                //i dunno know what id's to look for, i cannot navigate to the page that naturally comes after a log in
                
            }

        }

        [TestMethod]
        public void NoLogin_Valid_Should_VisitAllAllowedPages()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))
            {
                //set an implicit wait time before any search for an item fails
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

                //navigate to the kenworth page
                driver.Navigate().GoToUrl(Extensions.BaseUrl);

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Account-Done"));
                driver.FindElement(By.Id("View-Login-Done"));


                //click register, should take you to register page
                driver.FindElement(By.Id("registerLink")).Click();

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Account-Done"));
                driver.FindElement(By.Id("View-Register-Done"));

                //click log in, should take you to the log in page again
                driver.FindElement(By.Id("loginLink")).Click();

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Account-Done"));
                driver.FindElement(By.Id("View-Login-Done"));

                //click register as a new user link on login page
                driver.FindElement(By.Id("registerLinkOnPage")).Click();

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Account-Done"));
                driver.FindElement(By.Id("View-Register-Done"));

                //click contact, should take you to contact page
                driver.FindElement(By.Id("contactLinkNavBar")).Click();

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Home-Done"));
                driver.FindElement(By.Id("View-Contact-Done"));

                //click about, should take you to about page
                driver.FindElement(By.Id("aboutLinkNavBar")).Click();

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Home-Done"));
                driver.FindElement(By.Id("View-About-Done"));

                //click SetDatabase, should take you to the set database page
                //click contact, should take you to contact page
                driver.FindElement(By.Id("setDatabaseNavBar")).Click();

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Home-Done"));
                driver.FindElement(By.Id("View-SetDatabase-Done"));

                //click homescreen logo in top left, should take you to homepage(since not logged in this should be log in page)
                //click contact, should take you to contact page
                driver.FindElement(By.Id("homeLinkNavBar")).Click();

                //check that page is the right page
                //i don't know what id's to look for, link is broken


            }
        }

        //
    }
}
