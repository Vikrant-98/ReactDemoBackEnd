using CommonLayer.Request;
using CommonLayer.Responce;
using MySql.Data.MySqlClient;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class ServiceRL : IServiceRL
    {
        public MySqlConnection Connection { get; }

        public ServiceRL(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public static string add_Employee = "add_Employee";
        public static string all_Employee = "select * from employee;";
        public static string update_Employee = "update_employee";

        public async Task<List<EmployeeResponce>> EmployeeDetails()
        {

            List<EmployeeResponce> employee = new List<EmployeeResponce>();
            try
            {
                await Connection.OpenAsync();

                using var command = new MySqlCommand(all_Employee, Connection);
                using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    while (await reader.ReadAsync().ConfigureAwait(false))
                    {
                        employee.Add(new EmployeeResponce()
                        {
                            EmployeeID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Designation = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                await Connection.CloseAsync().ConfigureAwait(false);
            }
            return employee;

        }

        public async Task<List<EmployeeResponce>> AddEmployeeDetails(EmployeeDetails details)
        {
            MySqlCommand cmd = null;
            List<EmployeeResponce> employee = new List<EmployeeResponce>();
            try
            {
                await Connection.OpenAsync();


                cmd = Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = add_Employee;
                cmd.Parameters.AddWithValue("_FirstName", details.FirstName);
                cmd.Parameters.AddWithValue("_LastName", details.LastName);
                cmd.Parameters.AddWithValue("_Designation", details.Designation);
                cmd.Parameters.AddWithValue("_Email", details.Email);
                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    while (await reader.ReadAsync().ConfigureAwait(false))
                    {
                        employee.Add(new EmployeeResponce()
                        {
                            EmployeeID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Designation = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await Connection.CloseAsync().ConfigureAwait(false);
            }
            return employee;

        }

        public async Task<List<EmployeeResponce>> UpdateEmployeeDetails(EmployeeDetails details,int EmployeeId)
        {
            MySqlCommand cmd = null;
            List<EmployeeResponce> employee = new List<EmployeeResponce>();
            try
            {
                await Connection.OpenAsync();


                cmd = Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = update_Employee;
                cmd.Parameters.AddWithValue("_EmployeeId", EmployeeId);
                cmd.Parameters.AddWithValue("_FirstName", details.FirstName);
                cmd.Parameters.AddWithValue("_LastName", details.LastName);
                cmd.Parameters.AddWithValue("_Designation", details.Designation);
                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    while (await reader.ReadAsync().ConfigureAwait(false))
                    {
                        employee.Add(new EmployeeResponce()
                        {
                            EmployeeID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            LastName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Designation = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await Connection.CloseAsync().ConfigureAwait(false);
            }
            return employee;

        }

    }
}
