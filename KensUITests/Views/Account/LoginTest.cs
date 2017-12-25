﻿using System;
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
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            LogIn(AssemblyTests.CurrentDriver, Extensions.ValidEmailAdmin1, Extensions.ValidPasswordAdmin1);

            //check that page is the right page
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }

        [TestMethod]
        public void Login_Valid_NonAdminLogin_Should_JumpToHomepage()
        {
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            LogIn(AssemblyTests.CurrentDriver, Extensions.ValidEmailNotAdmin1, Extensions.ValidPasswordNotAdmin1);

            //check that page is the right page
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }

        [TestMethod]
        public void LoginAndLogout_Valid_AdminLogin_Should_JumpToHomePage()
        {
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            LogIn(AssemblyTests.CurrentDriver, Extensions.ValidEmailAdmin1, Extensions.ValidPasswordAdmin1);

            LogOut(AssemblyTests.CurrentDriver);

            //check that page is the right one
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }

        [TestMethod]
        public void LoginAndLogout_Valid_NonAdminLogin_Should_JumpToHomePage()
        {
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            LogIn(AssemblyTests.CurrentDriver, Extensions.ValidEmailNotAdmin1, Extensions.ValidPasswordNotAdmin1);

            LogOut(AssemblyTests.CurrentDriver);

            //check that page is the right one
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }


        [TestMethod]
        public void NoLogin_Valid_Should_VisitAllAllowedPages()
        {
            //navigate to the page,being tested, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            //click register as a new user link on login page
            AssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.RegisterLinkIdTag)).Click();

            //check that page is the right page (should be register page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Account", "Register");


            //test NavBar links
            Views.Shared.LoginPartial.ClickNavBarNoLoginLinks(AssemblyTests.CurrentDriver, _Controller, _Action);
        }

        //INCOMPLETE
        [TestMethod]
        public void Login_Valid_RememberMeFunctionality_Should_Remember()
        {
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            //find the email box to input username info
            IWebElement emailBox = AssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginEmailInputBoxIdTag));

            //enter a valid email to login
            emailBox.SendKeys(Extensions.ValidEmailAdmin1);

            //find the password box to input password info  
            IWebElement passwordBox = AssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginPasswordInputBoxIdTag));

            //enter a valid password
            passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

            //click remember me button
            AssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.RemeberMeIdTag)).Click();

            //submit login info
            AssemblyTests.CurrentDriver.FindElement(By.Id(Extensions.LoginSubmitButtonIdTag)).Click();

            //now confirm remember me worked
            //BUT WHAT DOES IT DO IN THIS CASE YOU SEXY SLOOT?
        }

        //add happy path tests for
        // clicking any and all links - logged in or not - from every page
        //   toggling admin privleges
        // naviagating site without logging in 
        //
        //add bad paths for
        // log in
        // toggle admin privleges
        // database inputs
        // naviagting site without logging in


        //heres how to add tests for clicking all link:
        // create tests for ALL the shared view pages
        //  call those tests on all the other pages. This will avoid repeating code and also test all persistant links across all pages.

        //tests for other pages:
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
