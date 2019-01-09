using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreGeniusAPI.Model
{
    public class Employee
    {
        public int  empId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Dept { get; set; }
    }



    public class userRegistration
    {
        public int empId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string retypepassword { get; set; }
        public string email { get; set; }
    }





    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
