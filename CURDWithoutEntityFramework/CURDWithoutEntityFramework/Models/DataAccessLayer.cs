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

        //Get All and Get Details by id Operation 
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

        //Create Operation 
        public bool AddNewEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spInsertNew", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@Office", employee.Office);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    return true;
                else
                    return false;
            }

        }
        //Update Operation 
        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spUpdateRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@Office", employee.Office);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }
        //Delete Operation 
        public bool DeleteEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spDeleteRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }
    }
}