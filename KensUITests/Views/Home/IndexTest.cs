﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

//incomplete
//happy path
// for clicking all links, logged in or not
//
//bad path for
// clicking links?

namespace KensUITests.Views.Home
{
    [TestClass]
    public class IndexTest
    {
        private string _Controller = "Home";
        private string _Action = "Index";

        [TestMethod]
        public void HomeIndex_Valid_ClickAllLinks_NoLogin()
        {
            //navigate to the page,being tested, this function has validation built into it
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            //test nav bar links
            Views.Shared.LoginPartial.ClickNavBarNoLoginLinks(AssemblyTests.CurrentDriver, _Controller, _Action);

        }

        [TestMethod]
        public void HomeIndex_Valid_ClickAllLinks_AdminLogin()
        {
            //first log into an admin profile
            //navigate to log in page
            NavigateToPage(AssemblyTests.CurrentDriver, "Account", "Login");

            //admin log in
            LogIn(AssemblyTests.CurrentDriver, ValidEmailAdmin1, ValidPasswordAdmin1);

            //navigate to the page,being tested
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

            //test nav bar links
            Views.Shared.LoginPartial.ClickNavBarAdminLinks(AssemblyTests.CurrentDriver,_Controller,_Action);


        }

    }
}
