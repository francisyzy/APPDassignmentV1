using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDassignmentV1.Models
{
    class User
    {
        public static string currentuseremail = "";
        public static string getuser()
        {
            return currentuseremail;
        }
        public static void setUser(string user)
        {
            currentuseremail = user;
        }
    }
}
