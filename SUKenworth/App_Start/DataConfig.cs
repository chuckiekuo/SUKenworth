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
        public static SUKenworth.Models.TestDataModels.KenworthProjectsTestEntities TestDB;

        static DataConfig()
        {
            TestDB = new KenworthProjectsTestEntities();
        }

        public static void DirectCreate(User user)
        {
            TestDB.Users.Add(user);
            TestDB.SaveChanges();
        }

        public static void BulkDirectCreate(IEnumerable<User> inputList)
        {
            foreach (var user in inputList)
            {
                User temp = new User()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Admin = user.Admin
                };
                TestDB.Users.Add(temp);
            }
            TestDB.SaveChanges();
        }

        public static void DirectDelete(User user)
        {
            TestDB.Users.Remove(user);
        }

        public static void DirectUpdate(User user)
        {
            TestDB.Users.Remove(TestDB.Users.Find(user.Id));
            TestDB.Users.Add(user);
            TestDB.SaveChanges();
        }

        public static void ClearDataBase()
        {
            TestDB.Users.RemoveRange(TestDB.Users.ToList());

            TestDB.SaveChanges();
        }

        public static List<User> GetDataList()
        {
            return TestDB.Users.ToList();
        }
    }
}