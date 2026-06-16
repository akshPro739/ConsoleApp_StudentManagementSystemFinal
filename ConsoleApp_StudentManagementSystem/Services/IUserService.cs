using ConsoleApp_StudentManagementSystem.Models;

namespace ConsoleApp_StudentManagementSystem.Services
{
    public interface IUserService
    {
        User AuthenticateUserNameAndPassword(
            string username,
            string password);
    }
}