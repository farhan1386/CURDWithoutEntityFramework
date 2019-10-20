using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CURDWithoutEntityFramework.Models
{
    public class DataAccessLayer
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee =new Employee
                    {
                        Id= Convert.ToInt32(rdr["Id"]),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        Position = rdr["Position"].ToString(),
                        Office = rdr["Office"].ToString(),
                        Salary = Convert.ToInt32(rdr["Salary"]) 
                    };
                    employees.Add(employee);
                }
                return employees;
            }
        }
    }
}