using ConsoleApp_StudentManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsoleApp_StudentManagementSystem.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepositoryImpl(
            IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString(
                    "ConnStr");
        }

        public User AuthenticateUser(
            string username,
            string password)
        {
            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                using (SqlCommand command =
                    new SqlCommand(
                        "sp_AuthenticateUser",
                        connection))
                {
                    command.CommandType =
                        CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                        "@UserName",
                        username);

                    command.Parameters.AddWithValue(
                        "@UserPassword",
                        password);

                    connection.Open();

                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId =
                                Convert.ToInt32(
                                    reader["UserId"]),

                                UserName =
                                reader["UserName"]
                                .ToString(),

                                RoleId =
                                Convert.ToInt32(
                                    reader["RoleId"]),

                                StudentId =
                                reader["StudentId"]
                                == DBNull.Value
                                ? null
                                : Convert.ToInt32(
                                    reader["StudentId"]),

                                Role =
                                new Role
                                {
                                    RoleId =
                                    Convert.ToInt32(
                                        reader["RoleId"]),

                                    RoleName =
                                    reader["RoleName"]
                                    .ToString()
                                }
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}