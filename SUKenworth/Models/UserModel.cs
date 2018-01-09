using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUKenworth.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }
    }
}