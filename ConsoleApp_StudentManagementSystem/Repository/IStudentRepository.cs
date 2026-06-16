using ConsoleApp_StudentManagementSystem.Models;

namespace ConsoleApp_StudentManagementSystem.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);

        Student GetStudentByUserId(int userId);
    }
}