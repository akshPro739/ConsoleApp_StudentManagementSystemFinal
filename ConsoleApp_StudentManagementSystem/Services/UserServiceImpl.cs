using ConsoleApp_StudentManagementSystem.Models;
using ConsoleApp_StudentManagementSystem.Repository;

namespace ConsoleApp_StudentManagementSystem.Services
{
    public class UserServiceImpl
        : IUserService
    {
        private readonly IUserRepository
            _userRepository;

        public UserServiceImpl(
            IUserRepository userRepository)
        {
            _userRepository =
                userRepository;
        }

        public User
            AuthenticateUserNameAndPassword(
            string username,
            string password)
        {
            return
                _userRepository
                .AuthenticateUser(
                    username,
                    password);
        }
    }
}