using ConsoleApp_StudentManagementSystem.Models;

namespace ConsoleApp_StudentManagementSystem.Repository
{
    public interface IUserRepository
    {
        User AuthenticateUser(
            string username,
            string password);
    }
}