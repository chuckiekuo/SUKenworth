﻿using System;
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

        //add tests for remeber me functionality
        //add tests for clicking each link from the log in page
    }
}
