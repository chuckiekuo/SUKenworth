﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static KensUITests.Extensions;

namespace KensUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITests
    {
        public CodedUITests()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void ValidLogInAndLogOffAdmin()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))//<-Add your path
            {
                //set an implicit wait time before any search for an item fails
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

                //navigate to the kenworth page
                driver.Navigate().GoToUrl(Extensions.BaseUrl);

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Account-Done"));
                driver.FindElement(By.Id("View-Login-Done"));

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

                //submit
                driver.FindElement(By.Id("LogInSubmit")).Click();

                //set a wait for page to render
                //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Extensions.MaxWaitTime));

                //set a wait until
                //IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Name("LogOffSubmit")));
                //wait.Until(d => d.FindElement(By.Name("LogOffSubmit")));

                //check that page is the right page
                //i don't know what id's to check, cannot get to this page


                //find the log out button and click it
                driver.FindElement(By.Id("LogOffSubmit")).Click();

                //check that page is the right page
                //i don't know what id's to check log off link is broken
                
            }
        }

        [TestMethod]
        public void ValidLogInAndLogOffNotAdmin()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))//<-Add your path
            {
                //set an implicit wait time before any search for an item fails
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

                //navigate to the kenworth page
                driver.Navigate().GoToUrl(Extensions.BaseUrl);

                //check that page is the right page
                driver.FindElement(By.Id("Page-Done"));
                driver.FindElement(By.Id("Area--Done"));
                driver.FindElement(By.Id("Controller-Account-Done"));
                driver.FindElement(By.Id("View-Login-Done"));

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailNotAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordNotAdmin1);

                //submit
                driver.FindElement(By.Id("LogInSubmit")).Click();

                //check that page is the right page
                //i don't know what i'ds to check for, link is broken

                //find the log out button and click it
                driver.FindElement(By.Id("LogOffSubmit")).Click();

                //check that page is the right page
                //link is broken

            }
        }
        //add happy path tests for
        // clicking any and all links - logged in or not
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

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
