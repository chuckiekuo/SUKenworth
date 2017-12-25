using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static KensUITests.Extensions;

namespace KensUITests.Views.Account
{
    [TestClass]
    public class RegisterTest
    {
        private string _Controller = "Account";
        private string _Action = "Register";

        [TestMethod]
        public void Register_Valid_NonAdmin_Should_JumpToHomepage()
        {
            NavigateToPage(AssemblyTests.CurrentDriver, _Controller, _Action);

        }

        //need to:
        // register a user
        //  needs a test db that can be wiped for that
        // registering invalid users
        //any other bad path things?
    }
}
