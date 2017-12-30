using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Shared
{
    public class LoginPartial
    {

        public static void ClickNavBarAdminLinks(IWebDriver currentDriver, string controller, string action, string user, string pass)
        {
            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click hello link should take you to manage index page
            currentDriver.FindElement(By.Id(Extensions.HelloNavBarIdTag)).Click();

            //check that page is the right page (manage index page)
            ValidatePageTransition(currentDriver, "Manage", "Index");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click admin link, should take you to the admin index page
            currentDriver.FindElement(By.Id(Extensions.AdminIndexNavBarIdTag)).Click();

            //check that page is the right page (admin index page)
            ValidatePageTransition(currentDriver, "Admin", "Index");


            //log off link
            // first log off
            LogOut(currentDriver);
            // check page is the right page
            ValidatePageTransition(currentDriver, "Home", "Index");

            // now log back in
            NavigateToPage(AssemblyTests.CurrentDriver, "Account", "Login");

            // admin log in
            LogIn(AssemblyTests.CurrentDriver, user, pass);


            //test other nav bar links
            Layout.ClickNavBarLinks(currentDriver, controller, action);
        }

        public static void ClickNavBarNonAdminLinks(IWebDriver currentDriver, string controller, string action, string user, string pass)
        {
            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click hello link should take you to log in page
            currentDriver.FindElement(By.Id(Extensions.HelloNavBarIdTag)).Click();

            //check that page is the right page (manage index page)
            ValidatePageTransition(currentDriver, "Manage", "Index");


            //log off link
            // first log off
            LogOut(currentDriver);
            // check page is the right page
            ValidatePageTransition(currentDriver, "Home", "Index");

            // now log back in
            NavigateToPage(AssemblyTests.CurrentDriver, "Account", "Login");

            // nonadmin log in
            LogIn(AssemblyTests.CurrentDriver, user, pass);


            //test other nav bar links
            Layout.ClickNavBarLinks(currentDriver, controller, action);
        }

        public static void ClickNavBarNoLoginLinks(IWebDriver currentDriver, string controller, string action)
        {
            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click log in, should take you to log in page
            currentDriver.FindElement(By.Id(Extensions.LogInNavBarIdTag)).Click();

            //check that page is the right page (should be log in page)
            ValidatePageTransition(currentDriver, "Account", "Login");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click register, should take you to register page
            currentDriver.FindElement(By.Id(Extensions.RegisterNavBarIdTag)).Click();

            //check that page is the right page (should be register page)
            ValidatePageTransition(currentDriver, "Account", "Register");


            //test other nav bar links
            Layout.ClickNavBarLinks(currentDriver, controller, action);
        }
    }
}
