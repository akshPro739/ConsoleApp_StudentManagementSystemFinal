using ConsoleApp_StudentManagementSystem.Models;
using ConsoleApp_StudentManagementSystem.Repository;

namespace ConsoleApp_StudentManagementSystem.Services
{
    public class StudentServiceImpl
        : IStudentService
    {
        private readonly IStudentRepository
            _studentRepository;

        public StudentServiceImpl(
            IStudentRepository studentRepository)
        {
            _studentRepository =
                studentRepository;
        }

        public IEnumerable<Student>
            GetAllStudents()
        {
            return _studentRepository
                .GetAllStudents();
        }

        public Student GetStudentById(
            int id)
        {
            return _studentRepository
                .GetStudentById(id);
        }

        public void AddStudent(
            Student student)
        {
            _studentRepository
                .AddStudent(student);
        }

        public void UpdateStudent(
            Student student)
        {
            _studentRepository
                .UpdateStudent(student);
        }

        public void DeleteStudent(
            int id)
        {
            _studentRepository
                .DeleteStudent(id);
        }

        public Student
            GetStudentByUserId(
            int userId)
        {
            return _studentRepository
                .GetStudentByUserId(userId);
        }

        
    }
}