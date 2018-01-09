namespace SUKenworth.Controllers.Backend
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;
    using System.Xml.Linq;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data.Entity.Core.EntityClient;
    using SUKenworth.App_Start;
    using SUKenworth.Models;

    public class DataController : Controller
    {
        // Dictionary instead??
        private struct Queries
        {
            public string SelectAll { get; set; }
            public string DeleteAll { get; set; }
            public string SelectUser { get; set; }
            public string CreateUser { get; set; }
            public string DeleteUser { get; set; }
            public string UpdateUser { get; set; }
        }

        private const string DEFAULT_DB = "MyLocalTestDatabase";

        private XDocument xmlDocument;

        private string connectionString;

        private SqlConnection myConnection;

        private Queries myQueries;

        public DataController (string dbName = DEFAULT_DB)
        {
            // Make Switch statement
            // Add benign DEFAULT case
            if(dbName == DEFAULT_DB)
            {
                connectionString = DataConfig.MyLocalTestDatabase;

                // TO-DO Complete CRUDIS Query set
                // Investigate how to pass complex SQL statement strings
                // Linq query for formatting and reformatting one data-set
                myQueries.SelectAll = "SELECT * FROM dbo.[User]";
                myQueries.DeleteAll = "DELETE * FROM dbo.[User]";
                myQueries.SelectUser = String.Empty;
                myQueries.CreateUser = String.Empty;//"INSER into dbo.[User] Values(\"\" + id + \",\" + username + \",\" + password + \",\" + admin + \"\")";
                myQueries.DeleteUser = String.Empty;
                myQueries.UpdateUser = String.Empty;
            }
            else
            {
                // TO-DO add info for additional Databases
            }

            myConnection = new SqlConnection(connectionString);
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();

            using (myConnection)
            {
                var command = new SqlCommand(myQueries.SelectAll, myConnection);
                myConnection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserModel tempUser = new UserModel();
                        Object[] columns = new Object[reader.FieldCount];

                        reader.GetValues(columns);

                        tempUser.Id = (int)columns[0];
                        tempUser.Username = (string)columns[1];
                        tempUser.Password = (string)columns[2];
                        tempUser.Admin = (bool)columns[3];

                        users.Add(tempUser);
                    }
                }
                myConnection.Close();
            }
            return users;
        }

        public void DirectCreate(UserModel user)
        {
            //not certain how to test so I am leaving it commented out
            /*
            int id = user.Id;
            string username = user.Username;
            string password = user.Password;
            bool admin = user.Admin;

            using (myConnection)
            {
                var command = new SqlCommand(myQueries.CreateUser, myConnection);
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            */
        }

        public void DirectDelete(UserModel user)
        {
            // JOSHUAAAAAAAAAAAAAAAAAAAAA
            //TO-DO Complete Method
            //Probably an DELETE do research
            //Parse Data
            //Open SQL Connection
        }

        public void DirectUpdate(UserModel user)
        {
            // DOMMMMMMMMM
            //TO-DO Complete Method
            //Probably an DELETE do research
            //Parse Data
            //Open SQL Connection
        }

        public void ClearDataBase()
        {
            //TO-DO Complete Method
            //WILLIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
            using (myConnection)
            {
                var command = new SqlCommand(myQueries.DeleteAll, myConnection);
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        // Set TestData
        public void InitTestData()
        {
            ClearDataBase();
            DefineTestData();
            LoadTestData();
        }


        private void LoadTestData()
        {
            List<UserModel> tempList = new List<UserModel>();

            // Extract test data from XDoc and store in List<>
            IEnumerable<XElement> users =
                from user in xmlDocument.Elements("Users").Elements("User")
                select user;

            // Convert XElement List<> into User List<>
            foreach (XElement user in users)
            {
                //  TO-DO: Rewrite using SqlConnection
            }
        }

        public void BulkDirectCreate(IEnumerable<UserModel> inputList)
        {
            foreach (var user in inputList)
            {
                UserModel temp = new UserModel()
                {
                    //  TO-DO: Rewrite using SqlConnection
                };
            }
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
                // Load local XML document, named [databaseName].data
                xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating an XML Tree using LINQ to XML"),

                new XElement("Users",

                    new XElement("User",
                        new XElement("Id", 101),
                        new XElement("Username", "Mark"),
                        new XElement("Password", "MARTHAAAAAA"),
                        new XElement("Admin", false)),

                    new XElement("User",
                        new XElement("Id", 102),
                        new XElement("Username", "Rosy"),
                        new XElement("Password", "password2"),
                        new XElement("Admin", false)),

                    new XElement("User",
                        new XElement("Id", 103),
                        new XElement("Username", "Pam"),
                        new XElement("Password", "mynewpassword"),
                        new XElement("Admin", false)),

                    new XElement("User",
                        new XElement("Id", 104),
                        new XElement("Username", "John"),
                        new XElement("Password", "abc##123"),
                        new XElement("Admin", false))));
            }

            // TO-DO: Define other test data sets
        }
    }
}
