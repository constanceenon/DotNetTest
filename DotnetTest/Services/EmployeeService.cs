using DotnetTest.Model;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTest.Services
{
    public class EmployeeService:IEmployeeService
    {
        private Employee _employee;
        private string _connectionString = Startup.StaticConfig["ConnectionStrings:DefaultConnection"];

        public int CreateEmployee(Employee model)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            string query = @"INSERT INTO [dbo].[Employee] (                   
                    [EmployeeName]
                    ,[Department ]
                    ,[DateOfJoining]
                    ,[Address]
                    ,[PhotoFileName]
       ) output INSERTED.EmployeeId 
            VALUES(@EmployeeName,@Department,@DateOfJoining,@Address,@PhotoFileName)";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.Add(new SqlParameter("@employeeName", model.EmployeeName));
            command.Parameters.Add(new SqlParameter("@department", model.Department));
            command.Parameters.Add(new SqlParameter("@dateOfJoining", model.DateOfJoining));
            command.Parameters.Add(new SqlParameter("@address", model.Address));
            command.Parameters.Add(new SqlParameter("@photoFileName", model.PhotoFileName));


            int Id = (int)command.ExecuteScalar();
            con.Close();

            return Id;
        }

      
        public Employee GetEmployee(int id)
        {
            Employee item = new Employee();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"SELECT [EmployeeId]
                    ,[EmployeeName]
                    ,[Department]
                    ,[DateOfJoining]
                    ,[Address]
                    ,[PhotoFileName]
                     FROM [dbo].[Employee] 
                     WHERE [EmployeeId] = @EmployeeId
                     ";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add(new SqlParameter("@EmployeeId", id));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            item.EmployeeName = reader["EmployeeName"].ToString();
                            item.Department = reader["Department"].ToString();
                            item.Address = reader["Address"].ToString();
                            item.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);                         
                            item.PhotoFileName = reader["PhotoFileName"].ToString();
                        }
                    }
                    
                }
            }
            return item;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> itemList = new List<Employee>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"SELECT [EmployeeId]
                    ,[EmployeeName]
                    ,[Department]
                    ,[DateOfJoining]
                    ,[Address]
                    ,[PhotoFileName]
                     FROM [dbo].[Employee] 
                     ";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee item = new Employee();
                            item.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            item.EmployeeName = reader["EmployeeName"].ToString();
                            item.Department = reader["Department"].ToString();
                            item.Address = reader["Address"].ToString();
                            item.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);
                            item.PhotoFileName = reader["PhotoFileName"].ToString();
                            itemList.Add(item);
                        }
                    }
                }
            }
            return itemList;
        }



        public int UpdateEmployee( Employee model)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            string query = @"UPDATE [dbo].[Employee]
            SET [EmployeeName] = ISNULL(@employeeName, [EmployeeName]), [Department] = ISNULL(@department,[Department]), [DateOfJoining] = ISNULL(@dateOfJoining,[DateOfJoining]), [Address] =ISNULL(@address,[Address]),[PhotoFileName] = ISNULL(@photoFileName,[PhotoFileName])
            WHERE [EmployeeId] = @employeeId";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.Add(new SqlParameter("@employeeId", model.EmployeeId));
            command.Parameters.Add(new SqlParameter("@employeeName", string.IsNullOrWhiteSpace(model.EmployeeName) ? (object)DBNull.Value : model.EmployeeName));
            command.Parameters.Add(new SqlParameter("@department", string.IsNullOrWhiteSpace(model.Department) ? (object)DBNull.Value : model.Department));
            command.Parameters.Add(new SqlParameter("@dateOfJoining", model.DateOfJoining > DateTime.MinValue ? (object)DBNull.Value : model.DateOfJoining));
            command.Parameters.Add(new SqlParameter("@address", string.IsNullOrWhiteSpace(model.Address) ? (object)DBNull.Value : model.Address));
            command.Parameters.Add(new SqlParameter("@photoFileName", string.IsNullOrWhiteSpace(model.PhotoFileName) ? (object)DBNull.Value : model.PhotoFileName));
            int rowcount = (int)command.ExecuteNonQuery();
            con.Close();

            return rowcount;
        }

        public bool DeleteEmployee(int id)
        {
            //bool result = false;
            //Create and open a connection to SQL Server 
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();

            //Create the SQL Query for deleting an article
            string query = @"DELETE [dbo].[Employee]
            WHERE [EmployeeId] = @employeeId";

            //Create a Command object
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.Add(new SqlParameter("@employeeId", id));
            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
           
            // Close and dispose
           
            con.Close();

            return rowsDeletedCount > 0;

        }

    }
}
