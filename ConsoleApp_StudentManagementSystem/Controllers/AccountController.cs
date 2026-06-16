using ConsoleApp_StudentManagementSystem.Services;
using ConsoleApp_StudentManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp_StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(
                new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(
            LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var availableUser =
                    _userService
                    .AuthenticateUserNameAndPassword(
                        loginViewModel.UserName,
                        loginViewModel.UserPassword);

                if (availableUser != null)
                {
                    Response.Cookies.Append(
                        "UserId",
                        availableUser.UserId.ToString());

                    Response.Cookies.Append(
                        "UserName",
                        availableUser.UserName);

                    Response.Cookies.Append(
                        "RoleId",
                        availableUser.RoleId.ToString());

                    Response.Cookies.Append(
                        "StudentId",
                        availableUser.StudentId?.ToString()
                        ?? "");

                    return RedirectToRoleBasedDashboard(
                        availableUser.RoleId);
                }

                ViewBag.ErrorMessage =
                    "Invalid Username or Password";
            }

            return View(loginViewModel);
        }

        private IActionResult
            RedirectToRoleBasedDashboard(
            int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return RedirectToAction(
                        "Dashboard",
                        "Students");

                case 2:
                    return RedirectToAction(
                        "MyRecord",
                        "Students");

                default:
                    return RedirectToAction(
                        "Login");
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserId");
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("RoleId");
            Response.Cookies.Delete("StudentId");

            return RedirectToAction(
                "Login");
        }
    }
}