using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Shared
{
    public class Layout
    {
        public static void ClickNavBarLinksNotLoggedIn(IWebDriver currentDriver, string controller, string action)
        {
            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click log in, should take you to log in page
            AssemblyTests.CurrentDriver.FindElement(By.Id("loginLink")).Click();

            //check that page is the right page (should be log in page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Account", "Login");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click register, should take you to register page
            AssemblyTests.CurrentDriver.FindElement(By.Id("registerLink")).Click();

            //check that page is the right page (should be register page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Account", "Register");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click contact, should take you to contact page
            AssemblyTests.CurrentDriver.FindElement(By.Id("contactLinkNavBar")).Click();

            //check that page is the right page (Should be contact page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Contact");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click about, should take you to about page
            AssemblyTests.CurrentDriver.FindElement(By.Id("aboutLinkNavBar")).Click();

            //check that page is the right page (Should be the about page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "About");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click SetDatabase, should take you to the set database page
            AssemblyTests.CurrentDriver.FindElement(By.Id("setDatabaseNavBar")).Click();

            //check that page is the right page (Should be setDatabase page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "SetDatabase");
            

            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click homescreen logo in top left, should take you to homepage
            AssemblyTests.CurrentDriver.FindElement(By.Id("homeLinkNavBar")).Click();

            //check that page is the right page
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }

        //INCOMPLETE
        public static void ClickNavBarLinksNotAdmin(IWebDriver currentDriver, string controller, string action)
        {
            //the log off link


            //the "Hello XXXX!" link


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click contact, should take you to contact page
            AssemblyTests.CurrentDriver.FindElement(By.Id("contactLinkNavBar")).Click();

            //check that page is the right page (Should be contact page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Contact");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click about, should take you to about page
            AssemblyTests.CurrentDriver.FindElement(By.Id("aboutLinkNavBar")).Click();

            //check that page is the right page (Should be the about page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "About");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click SetDatabase, should take you to the set database page
            AssemblyTests.CurrentDriver.FindElement(By.Id("setDatabaseNavBar")).Click();

            //check that page is the right page (Should be setDatabase page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "SetDatabase");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click homescreen logo in top left, should take you to homepage
            AssemblyTests.CurrentDriver.FindElement(By.Id("homeLinkNavBar")).Click();

            //check that page is the right page
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }

        //INCOMPLETE
        public static void ClickNavBarLinksAdmin(IWebDriver currentDriver, string controller, string action)
        {
            //the log off link


            //the admin link


            //the "Hello XXXX!" link


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click contact, should take you to contact page
            AssemblyTests.CurrentDriver.FindElement(By.Id("contactLinkNavBar")).Click();

            //check that page is the right page (Should be contact page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Contact");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click about, should take you to about page
            AssemblyTests.CurrentDriver.FindElement(By.Id("aboutLinkNavBar")).Click();

            //check that page is the right page (Should be the about page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "About");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click SetDatabase, should take you to the set database page
            AssemblyTests.CurrentDriver.FindElement(By.Id("setDatabaseNavBar")).Click();

            //check that page is the right page (Should be setDatabase page)
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "SetDatabase");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, controller, action);

            //click homescreen logo in top left, should take you to homepage
            AssemblyTests.CurrentDriver.FindElement(By.Id("homeLinkNavBar")).Click();

            //check that page is the right page
            ValidatePageTransition(AssemblyTests.CurrentDriver, "Home", "Index");
        }
    }
}
