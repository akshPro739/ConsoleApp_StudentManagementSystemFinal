using System.ComponentModel.DataAnnotations;

namespace ConsoleApp_StudentManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(30)]
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public int RoleId { get; set; }

        // Needed for Student Login
        public int? StudentId { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Property
        public virtual Role? Role { get; set; }
    }
}
