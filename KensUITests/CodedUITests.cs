using System;
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
        public void ValidLogInAdmin()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))//<-Add your path
            {
                //navigate to the kenworth page
                driver.Navigate().GoToUrl(Extensions.Homepage);

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

                //submit
                driver.FindElement(By.Name("LogInSubmit")).Click();

                //check that page is the right page


            }

        }

        [TestMethod]
        public void ValidLogInNotAdmin()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))//<-Add your path
            {
                //navigate to the kenworth page
                driver.Navigate().GoToUrl(Extensions.Homepage);

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailNotAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordNotAdmin1);

                //submit
                driver.FindElement(By.Name("LogInSubmit")).Click();

                //check that page is the right page

            }

        }

        [TestMethod]
        public void NoLogIn()
        {
            //!Make sure to add the path to where you extracting the chromedriver.exe:
            using (IWebDriver driver = new ChromeDriver(Extensions.ChromeDriverLocation))
            {
                //set an implicit wait time before any search for an item fails
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Extensions.MaxWaitTime);

                //navigate to the kenworth page
                driver.Navigate().GoToUrl(Extensions.Homepage);

                //check that page is the right page


                //click register, should take you to register page
                driver.FindElement(By.Id("registerLink")).Click();

                //check that page is the right page


                //click log in, should take you to the log in page again
                driver.FindElement(By.Id("loginLink")).Click();

                //check that page is the right page


                //click register as a new user link on login page
                driver.FindElement(By.Id("registerLinkOnPage")).Click();

                //check that page is the right page
                

                //click contact, should take you to contact page
                driver.FindElement(By.Id("contactLinkNavBar")).Click();

                //check that page is the right page
                

                //click about, should take you to about page
                driver.FindElement(By.Id("aboutLinkNavBar")).Click();

                //check that page is the right page


                //click SetDatabase, should take you to the set database page
                //click contact, should take you to contact page
                driver.FindElement(By.Id("setDatabaseNavBar")).Click();

                //check that page is the right page


                //click homescreen logo in top left, should take you to homepage(since not logged in this should be log in page)
                //click contact, should take you to contact page
                driver.FindElement(By.Id("homeLinkNavBar")).Click();

                //check that page is the right page


            }
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
                driver.Navigate().GoToUrl(Extensions.Homepage);

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordAdmin1);

                //submit
                driver.FindElement(By.Name("LogInSubmit")).Click();

                //set a wait for page to render
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Extensions.MaxWaitTime));

                //set a wait until
                //IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Name("LogOffSubmit")));
                wait.Until(d => d.FindElement(By.Name("LogOffSubmit")));

                //find the log out button and click it
                driver.FindElement(By.Name("LogOffSubmit")).Click();

                //check that page is the right page

                
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
                driver.Navigate().GoToUrl(Extensions.Homepage);

                //find the email box to input username info
                IWebElement emailBox = driver.FindElement(By.Id("Email"));

                //enter a valid email to login
                emailBox.SendKeys(Extensions.ValidEmailNotAdmin1);

                //find the password box to input password info    
                IWebElement passwordBox = driver.FindElement(By.Id("Password"));

                //enter a valid password
                passwordBox.SendKeys(Extensions.ValidPasswordNotAdmin1);

                //submit
                driver.FindElement(By.Name("LogInSubmit")).Click();

                //set a wait for page to render
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Extensions.MaxWaitTime));

                //set a wait until
                wait.Until(d => d.FindElement(By.Name("LogOffSubmit")));

                //find the log out button and click it
                driver.FindElement(By.Name("LogOffSubmit")).Click();

                //check that page is the right page


            }
        }
        //add happy path tests for
        // clicking any and all links
        //   toggling admin privleges
        // register a user
        //  needs a test db for that
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
