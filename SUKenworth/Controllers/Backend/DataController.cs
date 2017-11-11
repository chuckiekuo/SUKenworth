namespace SUKenworth.Controllers.Backend
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using SUKenworth.Models;
    using SUKenworth.Models.TestDataModels;
    using SUKenworth.App_Start;

    public class DataController : Controller
    {
        private XDocument xmlDocument;

        // GET: Data
        public void InitTestData()
        {
            ScrubDB();
            DefineTestData();
            LoadTestData();
        }

        private void ScrubDB()
        {
            // Clear out all pre-existing test data from the test Database
            DataConfig.ClearDataBase();
        }

        private void LoadTestData()
        {
            List<User> tempList = new List<User>();

            // Extract test data from XDoc and store in List<>
            IEnumerable<XElement> users =
                from user in xmlDocument.Elements("Users").Elements("User")
                select user;

            // Convert XElement List<> into User List<>
            foreach (XElement user in users)
            {
                if (user != null && user.Element("Id").Value != null)
                {
                    User tempUser = new User();
                    string x = user.Element("Id").Value;
                    if (int.TryParse(x, out int y))
                    {
                        tempUser.Id = y;
                    }

                    tempUser.Name = user.Element("Name").Value;
                    tempList.Add(tempUser);
                }
            }
            // Load User List<> into Test Database
            DataConfig.BulkDirectCreate(tempList);
        }

        private void DefineTestData(int dataSetCode = 1)
        {
            // The sub elements of each XElement 'User' must match the fields of the SQL Table
            // they are intended for EXACTLY.

            // Select desired test data set

            // Default test data set
            if (dataSetCode == 1)
            {

                // Load test data set into XDoc
                xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating an XML Tree using LINQ to XML"),

                new XElement("Users",

                    new XElement("User",
                        new XElement("Id", 101),
                        new XElement("Name", "Mark")),

                    new XElement("User",
                        new XElement("Id", 102),
                        new XElement("Name", "Rosy")),

                    new XElement("User",
                        new XElement("Id", 103),
                        new XElement("Name", "Pam")),

                    new XElement("User",
                        new XElement("Id", 104),
                        new XElement("Name", "John"))));
            }

            // TO-DO: Define other test data sets
        }
        public List<User> GetTestData()
        {
            return DataConfig.GetDataList();
        }
    }
}
