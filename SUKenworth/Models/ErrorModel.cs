using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUKenworth.Models
{
    public partial class ErrorModel
    {
        public int mErrorCode { get; set; }
        List<string> errors = new List<string>(new string[] 
        {
            "Default error",
            ""
        });

        public string getError(int i)
        {
            return errors[i];
        }
    }
    
}
