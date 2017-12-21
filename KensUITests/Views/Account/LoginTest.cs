using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Account
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
            NavigateToPage(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //find the email box to input username info
            IWebElement emailBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(Extensions.ValidEmailAdmin1);

            //find the password box to input password info  
            IWebElement passwordBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

            //submit
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginSubmitButtonIdTag)).Click();

            //check that page is the right page
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "Index");
        }

        [TestMethod]
        public void Login_Valid_NonAdminLogin_Should_JumpToHomepage()
        {
            NavigateToPage(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //find the email box to input username info
            IWebElement emailBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(Extensions.ValidEmailNotAdmin1);

            //find the password box to input password info    
            IWebElement passwordBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(Extensions.ValidPasswordNotAdmin1);

            //submit
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginSubmitButtonIdTag)).Click();

            //check that page is the right page
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "Index");
        }

        [TestMethod]
        public void LoginAndLogout_Valid_AdminLogin_Should_JumpToHomePage()
        {
            NavigateToPage(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //find the email box to input username info
            IWebElement emailBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(Extensions.ValidEmailAdmin1);

            //find the password box to input password info  
            IWebElement passwordBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

            //submit
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginSubmitButtonIdTag)).Click();

            //find the log out button and click it
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LogoutIdTag)).Click();

            //check that page is the right one
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "Index");
        }

        [TestMethod]
        public void LoginAndLogout_Valid_NonAdminLogin_Should_JumpToHomePage()
        {
            NavigateToPage(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //find the email box to input username info
            IWebElement emailBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(Extensions.ValidEmailNotAdmin1);

            //find the password box to input password info  
            IWebElement passwordBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(Extensions.ValidPasswordNotAdmin1);

            //submit
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginSubmitButtonIdTag)).Click();

            //find the log out button and click it
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LogoutIdTag)).Click();

            //check that page is the right one
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "Index");
        }


        [TestMethod]
        public void NoLogin_Valid_Should_VisitAllAllowedPages()
        {
            //navigate to the kenworth page, this function has validation built into it
            NavigateToPage(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //click register, should take you to register page
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("registerLink")).Click();

            //check that page is the right page (should be register page)
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Account", "Register");


            //click log in, should take you to the log in page again
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("loginLink")).Click();

            //manually validate (because we are clicking link and not entering urls)
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //click register as a new user link on login page
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("registerLinkOnPage")).Click();

            //check that page is the right page (should be register page)
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Account", "Register");


            //click log in, should take you to the log in page again
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("loginLink")).Click();

            //manually validate
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //click contact, should take you to contact page
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("contactLinkNavBar")).Click();

            //check that page is the right page (Should be contact page)
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "Contact");


            //click log in, should take you to the log in page again
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("loginLink")).Click();

            //manually validate
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //click about, should take you to about page
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("aboutLinkNavBar")).Click();

            //check that page is the right page (Should be the about page)
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "About");


            //click log in, should take you to the log in page again
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("loginLink")).Click();

            //manually validate
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //click SetDatabase, should take you to the set database page
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("setDatabaseNavBar")).Click();

            //check that page is the right page (Should be setDatabase page)
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "SetDatabase");


            //click log in, should take you to the log in page again
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("loginLink")).Click();

            //manually validate
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //click homescreen logo in top left, should take you to homepage
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("homeLinkNavBar")).Click();
            
            //check that page is the right page
            ValidatePageTransition(LoginAssemblyTests.CurrentDriver, "Home", "Index");
        }

        //INCOMPLETE
        [TestMethod]
        public void Login_Valid_RememberMeFunctionality_Should_Remember()
        {
            NavigateToPage(LoginAssemblyTests.CurrentDriver, _Controller, _Action);

            //find the email box to input username info
            IWebElement emailBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(Extensions.ValidEmailAdmin1);

            //find the password box to input password info  
            IWebElement passwordBox = LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

            //click remember me button
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id("RememberMe")).Click();

            //submit login info
            LoginAssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginSubmitButtonIdTag)).Click();

            //now confirm remember me worked
            //BUT WHAT DOES IT DO IN THIS CASE YOU SEXY SLOOT?
        }

        //add happy path tests for
        // clicking any and all links - logged in or not - from every page
        //   toggling admin privleges
        // register a user
        //  needs a test db that can be wiped for that
        // naviagating site without logging in 
        //
        //add bad paths for
        // log in
        // toggle admin privleges
        // database inputs
        // naviagting site without logging in
        //

        //heres how to add tests for clicking all link:
        // create tests for ALL the shared view pages
        //  call those tests on all the other pages. This will avoid repeating code and also test all persistant links across all pages.

        //tests for other pages:
        // account->register
        // account->ANY others??
        // admin->index
        // home->about
        // home->contact
        // home->index
        // home->error
        // home->setdatabase
        // mannage-> just do all of it
    }
}
