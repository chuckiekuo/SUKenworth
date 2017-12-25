using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Shared
{
    public class Layout
    {
        public static void ClickNavBarLinks(IWebDriver currentDriver, string controller, string action)
        {
            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click contact, should take you to contact page
            currentDriver.FindElement(By.Id("contactLinkNavBar")).Click();

            //check that page is the right page (Should be contact page)
            ValidatePageTransition(currentDriver, "Home", "Contact");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click about, should take you to about page
            currentDriver.FindElement(By.Id("aboutLinkNavBar")).Click();

            //check that page is the right page (Should be the about page)
            ValidatePageTransition(currentDriver, "Home", "About");


            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click SetDatabase, should take you to the set database page
            currentDriver.FindElement(By.Id("setDatabaseNavBar")).Click();

            //check that page is the right page (Should be setDatabase page)
            ValidatePageTransition(currentDriver, "Home", "SetDatabase");
            

            //navigate to the original page, this function has validation built into it
            NavigateToPage(currentDriver, controller, action);

            //click homescreen logo in top left, should take you to homepage
            currentDriver.FindElement(By.Id("homeLinkNavBar")).Click();

            //check that page is the right page
            ValidatePageTransition(currentDriver, "Home", "Index");
        }
    }
}
