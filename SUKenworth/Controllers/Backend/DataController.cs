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

        }

        private void ScrubDB()
        {
            // Clear out all pre-existing test data from the test Database
            DataConfig.ClearDataBase();
        }

        private void LoadTestData()
        {
 
        }

        private void DefineTestData(int dataSetCode = 1)
        {
            // The sub elements of each XElement must match the fields of the SQL Table
            // they are intended for EXACTLY.

            // Select desired test data set

            // Default test data set

            // TO-DO: Define other test data sets
        }
        public List<User> GetTestData()
        {
            return DataConfig.GetDataList();
        }
    }
}
