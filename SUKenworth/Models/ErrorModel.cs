using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// ErrorModel can store custom error messages in the form of a list
namespace SUKenworth.Models
{
    public partial class ErrorModel
    {
        //index(key) to the particular error message
        public int MErrorCode { get; set; }

        List<string> errors = new List<string>(new string[]
        {
            "Default error",
            String.Empty
        });

        public string GetError(int i)
        {
            return errors[i];
        }
    }
    
}
