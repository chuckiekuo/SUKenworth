using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

//incomplete
//need to:
// register a user
//  needs a test db that can be wiped for that
// registering invalid users
//any other bad path things?

namespace KensUITests.Views.Account
{
    [TestClass]
    public class RegisterTest
    {
        private string _Controller = "Account";
        private string _Action = "Register";

        [TestInitialize]
        public void NavigateToAboutPage()
        {
            //general test initialize
            AssemblyTests.AssemblyTestInitialize();

            //navigate to page being tested
            AssemblyTests.CurrentDriver.Navigate().GoToUrl(AssemblyTests.UrlPrefix + _Controller + "/" + _Action);

        }

        [TestMethod]
        public void Register_Valid_NonAdmin_Should_JumpToHomepage()
        {
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

        }

        [TestCleanup]
        public void RegisterTestCleanup()
        {
            //general cleanup
            AssemblyTests.AssemblyTestCleanup();
        }
    }
}
