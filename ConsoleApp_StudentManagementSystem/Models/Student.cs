using System.ComponentModel.DataAnnotations;

namespace ConsoleApp_StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string? RollNumber { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(30,
            ErrorMessage = "Name cannot exceed 30 characters")]
        public string Name { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Maths marks must be between 1 and 100")]
        public int Maths { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Physics marks must be between 1 and 100")]
        public int Physics { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Chemistry marks must be between 1 and 100")]
        public int Chemistry { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "English marks must be between 1 and 100")]
        public int English { get; set; }

        [Required]
        [Range(1, 100,
            ErrorMessage = "Programming marks must be between 1 and 100")]
        public int Programming { get; set; }

        public bool IsActive { get; set; } = true;

        public int TotalMarks
        {
            get
            {
                return Maths +
                       Physics +
                       Chemistry +
                       English +
                       Programming;
            }
        }

        public double Percentage
        {
            get
            {
                return TotalMarks / 5.0;
            }
        }
    }
}