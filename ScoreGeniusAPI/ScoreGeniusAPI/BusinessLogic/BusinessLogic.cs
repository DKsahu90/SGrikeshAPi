using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreGeniusAPI.DataAccessLayer;
using System.Data;
using ScoreGeniusAPI.Model;

namespace ScoreGeniusAPI.BusinessLogic
{
    public class BusinessLogic
    {
        ScoreGeniusAPI.DataAccessLayer.DataAccessLayer dal = new ScoreGeniusAPI.DataAccessLayer.DataAccessLayer();
        public int SaveEmplyee(Employee emp)
        {
            int res = dal.InsertEmployee(emp);
            return res;
        }
       public bool  ValidateUser(UserLogin login)
        {
           bool res= dal.ValidateUser( login);
            return res;
        }


        public int userRegistration(userRegistration reg)
        {
            int res = dal.InsertUserRegistration(reg);
            return res;
        }

        public DataTable GetEmployee()
        {
            DataTable dt = dal.GetEmployee();
            return dt;
        }
        public int DeleteEmployee(int empId)
        {
            int res = dal.DeleteEmployee(empId);
            return res;
        }

        public int EditEmployee(Employee emp)
        {
            int res = dal.EditEmployee(emp);
            return res;
        }
       

        public DataTable GetEmployeeByID(int empId)
        {
            DataTable dt = dal.GetEmployeeByID(empId);
            return dt;
        }
    }
}
