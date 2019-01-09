using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using ScoreGeniusAPI.Model;

namespace ScoreGeniusAPI.DataAccessLayer
{
    public class DataAccessLayer
    {
        SqlConnection conn;
        string ConnectionString = string.Empty;

        public DataAccessLayer()
        {
            ConnectionString = "Data Source=sgirdb017v.cmkmodxnbj0u.eu-west-1.rds.amazonaws.com;Initial Catalog=SGDB;User id=A12142;Password=iprdatabase123;";
            conn = new SqlConnection(ConnectionString);

        }

        public bool ValidateUser(UserLogin login)
        {
            SqlCommand cmd = new SqlCommand("Sp_login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", login.UserName);
            cmd.Parameters.AddWithValue("@pass", login.Password);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            if(dt.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public int InsertEmployee(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("Sp_AddEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name",emp.Name);
            cmd.Parameters.AddWithValue("email", emp.Email);
            cmd.Parameters.AddWithValue("phone", emp.Phone);
            cmd.Parameters.AddWithValue("dept", emp.Dept);

            conn.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                return 1;
            }
            conn.Close();
            return 0;
        }



        public int InsertUserRegistration(userRegistration reg)
        {
            SqlCommand cmd = new SqlCommand("Sp_AddUserRegistration", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", reg.name);
            cmd.Parameters.AddWithValue("Password", reg.password);
            cmd.Parameters.AddWithValue("ReTypepass", reg.retypepassword);
            cmd.Parameters.AddWithValue("Email", reg.email);

            conn.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                return 1;
            }
            conn.Close();
            return 0;
        }



        public DataTable GetEmployee()
        {
            SqlCommand cmd = new SqlCommand("Sp_S_GetEmplyee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            conn.Close();
            return dt;
        }

        public int Insertlogin(UserLogin log)
        {
            SqlCommand cmd = new SqlCommand("Sp_login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("username", log.UserName );
            cmd.Parameters.AddWithValue("password", log.Password );
            

            conn.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                return 1;
            }
            conn.Close();
            return 0;
        }
        public int DeleteEmployee(int empId )
        {
            SqlCommand cmd = new SqlCommand("Sp_D_delEmpByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("empId", empId);
          

            conn.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                return 1;
            }
            conn.Close();
            return 0;
        }



        public DataTable GetEmployeeByID(int empId)
        {
            SqlCommand cmd = new SqlCommand("Sp_S_GetEmpByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("empId", empId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            conn.Close();
            return dt;
        }

    
        public int EditEmployee(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("Sp_U_UpdateEmpByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("empId", emp.empId);
            cmd.Parameters.AddWithValue("name", emp.Name);
            cmd.Parameters.AddWithValue("email", emp.Email);
            cmd.Parameters.AddWithValue("phone", emp.Phone);
            cmd.Parameters.AddWithValue("dept", emp.Dept);

            conn.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                return 1;
            }
            conn.Close();
            return 0;
        }



    }
}
