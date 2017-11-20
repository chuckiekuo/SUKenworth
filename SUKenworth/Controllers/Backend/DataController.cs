namespace SUKenworth.Controllers.Backend
{
    using System;
     using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;
    using System.Xml.Linq;
    using SUKenworth.Models.TestDataModels;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data.Entity.Core.EntityClient;



    public class DataController : Controller
    {
        private struct Queries
        {
            public string SelectAll { get; set; }
            public string SelectUser { get; set; }
            public string CreateUser { get; set; }
            public string DeleteUser { get; set; }
            public string UpdateUser { get; set; }
        }

        private const string DEFAULT_DB = "KenworthProjectsTestEntities";
        private const string DEFAULT_PROVIDER = "System.Data.SqlClient";

        private XDocument xmlDocument;

        private string connectionString;

        private SqlConnection myConnection;

        private Queries myQueries;

        public DataController (string dbName = DEFAULT_DB)
        {
            connectionString = "data source = kenworthprojects.database.windows.net; initial catalog = KenworthProjectsTest; persist security info = True; user id = su_admin; password = Kenworth!; MultipleActiveResultSets = True; App = EntityFramework";

            if (dbName == DEFAULT_DB)
            {
                myQueries.SelectAll = "SELECT * FROM dbo.User";
                myQueries.SelectUser = "";
                myQueries.CreateUser = "";
                myQueries.DeleteUser = "";
                myQueries.UpdateUser = "";
            }
        }

        public void NewConnection(string SQLConnection)
        {
            connectionString = SQLConnection;
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
            }
            return users;
        }

        public void DirectCreate(UserModel user)
        {

        }

        public void DirectDelete(UserModel user)
        {

        }

        public void DirectUpdate(UserModel user)
        {

        }

        public void ClearDataBase()
        {

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
                if (user != null && user.Element("Id").Value != null)
                {
                    UserModel tempUser = new UserModel();
                    string x = user.Element("Id").Value;
                    if (int.TryParse(x, out int y))
                    {
                        tempUser.Id = y;
                    }

                    tempUser.Username = user.Element("Username").Value;
                    tempUser.Password = user.Element("Password").Value;
                    tempUser.Admin = Convert.ToBoolean(user.Element("Admin").Value);
                    tempList.Add(tempUser);
                }
            }
            // Load User List<> into Test Database
            BulkDirectCreate(tempList);
        }

        public void BulkDirectCreate(IEnumerable<UserModel> inputList)
        {
            foreach (var user in inputList)
            {
                UserModel temp = new UserModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Admin = user.Admin
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
