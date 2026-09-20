using ASPNETMVCCRUDADOSPDROP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ASPNETMVCCRUDADOSPDROP.DAL
{
    public class EmployeeRepository
    {
        DbHelper db = new DbHelper();

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();

            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new EmployeeModel
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        Salary = Convert.ToDecimal(dr["Salary"])
                    });
                }
            }
            return list;
        }

        public void Insert(EmployeeModel emp)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(EmployeeModel emp)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> list = new List<DepartmentModel>();

            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new DepartmentModel
                    {
                        DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                        DepartmentName = dr["DepartmentName"].ToString()
                    });
                }
            }
            return list;
        }

        
    }
}