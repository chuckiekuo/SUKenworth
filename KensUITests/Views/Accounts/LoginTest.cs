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

        [TestMethod]
        public void Login_Valid_CorrectLogin_Should_JumpToHomepage()
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
                driver.FindElement(By.Name("LogInSubmit")).Click();

                //check that page is the right page
                //i dunno know what id's to look for, i cannot navigate to the page that naturally comes after a log in
                ValidatePageTransition(driver, "Home", "Index");

            }

        }
    }
}
