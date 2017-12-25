using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Shared
{
    public class LoginPartial
    {

        public static void ClickNavBarAdminLinks()
        {

        }

        public static void ClickNavBarNonAdminLinks()
        {

        }

        public static void ClickNavBarNoLoginLinks(IWebDriver currentDriver, string controller, string action)
        {
            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click log in, should take you to log in page
            currentDriver.FindElement(By.Id("loginLink")).Click();

            //check that page is the right page (should be log in page)
            ValidatePageTransition(currentDriver, "Account", "Login");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click register, should take you to register page
            currentDriver.FindElement(By.Id("registerLink")).Click();

            //check that page is the right page (should be register page)
            ValidatePageTransition(currentDriver, "Account", "Register");
        }
    }
}
