namespace SUKenworth.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SUKenworth.Models;
    using SUKenworth.Models.TestDataModels;
    using SUKenworth.Controllers.Backend;

    public static class DataConfig
    {
        public static SUKenworth.Models.TestDataModels.TestDatabaseEntities TestDB;

        static DataConfig()
        {
            TestDB = new TestDatabaseEntities();
        }

        public static void DirectCreate(User user)
        {

        }

        public static void BulkDirectCreate(IEnumerable<User> inputList)
        {

        }

        public static void DirectDelete(User user)
        {

        }

        public static void DirectUpdate(User user)
        {

        }

        public static void ClearDataBase()
        {

        }

        public static List<User> GetDataList()
        {
            return TestDB.Users.ToList();
        }
    }
}