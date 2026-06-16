using ConsoleApp_StudentManagementSystem.Models;
using ConsoleApp_StudentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp_StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(
            IStudentService studentService)
        {
            _studentService = studentService;
        }

        private bool IsAdmin()
        {
            return Request.Cookies["RoleId"] == "1";
        }

        public IActionResult Dashboard()
        {
            if (!IsAdmin())
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            return View();
        }

        [HttpGet]
        public IActionResult List(string searchTerm)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var students =
                _studentService
                .GetAllStudents();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                students = students.Where(s =>
                    s.Name.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            ViewBag.SearchTerm = searchTerm;

            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            Student student =
                _studentService
                .GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                Random random = new Random();

                student.RollNumber =
                    random.Next(10000, 99999)
                    .ToString();

                _studentService
                    .AddStudent(student);

                return RedirectToAction(nameof(List));
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            Student student =
                _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);

                return RedirectToAction(nameof(List));
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            _studentService.DeleteStudent(id);

            return RedirectToAction(nameof(List));
        }

        // Student Only
        public IActionResult MyRecord()
        {
            // Only Student can access
            if (Request.Cookies["RoleId"] != "2")
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            string userIdCookie =
                Request.Cookies["UserId"];

            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            int userId =
                Convert.ToInt32(userIdCookie);

            Student student =
                _studentService
                .GetStudentByUserId(userId);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public JsonResult UpdateMarksAjax(Student student)
        {
            try
            {
                _studentService.UpdateStudent(student);

                return Json(new
                {
                    success = true,
                    message = "Marks updated successfully"
                });
            }
            catch
            {
                return Json(new
                {
                    success = false,
                    message = "Update failed"
                });
            }
        }
    }
}



















//using ConsoleApp_StudentManagementSystem.Models;
//using ConsoleApp_StudentManagementSystem.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace ConsoleApp_StudentManagementSystem.Controllers
//{
//    public class StudentsController : Controller
//    {
//        private readonly IStudentService _studentService;

//        public StudentsController(
//            IStudentService studentService)
//        {
//            _studentService = studentService;
//        }


//        private bool IsAdmin()
//        {
//            return Request.Cookies["RoleId"] == "1";
//        }

//        public IActionResult Dashboard()
//        {
//            return View();
//        }


//        [HttpGet]
//        public IActionResult List(string searchTerm)
//        {
//            var students =
//                _studentService
//                .GetAllStudents();

//            if (!string.IsNullOrWhiteSpace(searchTerm))
//            {
//                students = students.Where(s =>
//                    s.Name.Contains(
//                        searchTerm,
//                        StringComparison.OrdinalIgnoreCase)
//                ).ToList();
//            }

//            ViewBag.SearchTerm = searchTerm;

//            return View(students);
//        }


//        [HttpGet]
//        public IActionResult Details(int id)
//        {
//            Student student =
//                _studentService
//                .GetStudentById(id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Student student)
//        {
//            if (ModelState.IsValid)
//            {
//                Random random = new Random();

//                student.RollNumber =
//                    random.Next(10000, 99999)
//                    .ToString();

//                _studentService
//                    .AddStudent(student);

//                return RedirectToAction(
//                    nameof(List));
//            }

//            return View(student);
//        }


//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            Student student =
//                _studentService.GetStudentById(id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Student student)
//        {
//            if (ModelState.IsValid)
//            {
//                _studentService.UpdateStudent(student);

//                return RedirectToAction(nameof(List));
//            }

//            return View(student);
//        }

//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            _studentService.DeleteStudent(id);

//            return RedirectToAction(nameof(List));
//        }

//        public IActionResult MyRecord()
//        {
//            string userIdCookie =
//                Request.Cookies["UserId"];

//            if (string.IsNullOrEmpty(userIdCookie))
//            {
//                return RedirectToAction(
//                    "Login",
//                    "Account");
//            }

//            int userId =
//                Convert.ToInt32(userIdCookie);

//            Student student =
//                _studentService
//                .GetStudentByUserId(userId);

//            return View(student);
//        }



//    }
//}