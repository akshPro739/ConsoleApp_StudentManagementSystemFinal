using ConsoleApp_StudentManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsoleApp_StudentManagementSystem.Repository
{
    public class StudentRepositoryImpl : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepositoryImpl(
            IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString(
                    "ConnStr");
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students =
                new List<Student>();

            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                if (connection != null)
                {
                    connection.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_GetAllStudents",
                            connection);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    using (SqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student =
                                new Student();

                            student.Id =
                                Convert.ToInt32(
                                    reader["Id"]);

                            student.RollNumber =
                                reader["RollNumber"]
                                .ToString();

                            student.Name =
                                reader["Name"]
                                .ToString();

                            student.Maths =
                                Convert.ToInt32(
                                    reader["Maths"]);

                            student.Physics =
                                Convert.ToInt32(
                                    reader["Physics"]);

                            student.Chemistry =
                                Convert.ToInt32(
                                    reader["Chemistry"]);

                            student.English =
                                Convert.ToInt32(
                                    reader["English"]);

                            student.Programming =
                                Convert.ToInt32(
                                    reader["Programming"]);

                            student.IsActive =
                                Convert.ToBoolean(
                                    reader["IsActive"]);

                            students.Add(student);
                        }
                    }

                    connection.Close();
                }
            }

            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = null;

            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                if (connection != null)
                {
                    connection.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_GetStudentById",
                            connection);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        id);

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        student = new Student()
                        {
                            Id =
                            Convert.ToInt32(
                                reader["Id"]),

                            RollNumber =
                            reader["RollNumber"]
                            .ToString(),

                            Name =
                            reader["Name"]
                            .ToString(),

                            Maths =
                            Convert.ToInt32(
                                reader["Maths"]),

                            Physics =
                            Convert.ToInt32(
                                reader["Physics"]),

                            Chemistry =
                            Convert.ToInt32(
                                reader["Chemistry"]),

                            English =
                            Convert.ToInt32(
                                reader["English"]),

                            Programming =
                            Convert.ToInt32(
                                reader["Programming"]),

                            IsActive =
                            Convert.ToBoolean(
                                reader["IsActive"])
                        };
                    }
                }

                return student;
            }
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                if (connection != null)
                {
                    connection.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_InsertStudent",
                            connection);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@RollNumber",
                        student.RollNumber);

                    cmd.Parameters.AddWithValue(
                        "@Name",
                        student.Name);

                    cmd.Parameters.AddWithValue(
                        "@Maths",
                        student.Maths);

                    cmd.Parameters.AddWithValue(
                        "@Physics",
                        student.Physics);

                    cmd.Parameters.AddWithValue(
                        "@Chemistry",
                        student.Chemistry);

                    cmd.Parameters.AddWithValue(
                        "@English",
                        student.English);

                    cmd.Parameters.AddWithValue(
                        "@Programming",
                        student.Programming);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                if (connection != null)
                {
                    connection.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_UpdateStudent",
                            connection);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        student.Id);

                    cmd.Parameters.AddWithValue(
                        "@Name",
                        student.Name);

                    cmd.Parameters.AddWithValue(
                        "@Maths",
                        student.Maths);

                    cmd.Parameters.AddWithValue(
                        "@Physics",
                        student.Physics);

                    cmd.Parameters.AddWithValue(
                        "@Chemistry",
                        student.Chemistry);

                    cmd.Parameters.AddWithValue(
                        "@English",
                        student.English);

                    cmd.Parameters.AddWithValue(
                        "@Programming",
                        student.Programming);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                if (connection != null)
                {
                    connection.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_DeleteStudent",
                            connection);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public Student GetStudentByUserId(int userId)
        {
            Student student = null;

            using (SqlConnection connection =
                new SqlConnection(_connectionString))
            {
                if (connection != null)
                {
                    connection.Open();

                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_GetStudentByUserId",
                            connection);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@UserId",
                        userId);

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        student = new Student()
                        {
                            Id =
                            Convert.ToInt32(reader["Id"]),

                            RollNumber =
                            reader["RollNumber"].ToString(),

                            Name =
                            reader["Name"].ToString(),

                            Maths =
                            Convert.ToInt32(reader["Maths"]),

                            Physics =
                            Convert.ToInt32(reader["Physics"]),

                            Chemistry =
                            Convert.ToInt32(reader["Chemistry"]),

                            English =
                            Convert.ToInt32(reader["English"]),

                            Programming =
                            Convert.ToInt32(reader["Programming"]),

                            IsActive =
                            Convert.ToBoolean(reader["IsActive"])
                        };
                    }
                }

                return student;
            }
        }
    }
}