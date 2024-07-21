using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Courses
{
    public class UpdateCourse
    {
        [Required]
        public int Id { get; set; }

        [StringLength(3, ErrorMessage = "Course code can contain only 3 characters")]
        public string CourseCode { get; set; }

        [StringLength(30, ErrorMessage = "Course name can contain max 30 characters")]
        public string CourseName { get; set; }

        [Range(1, 11, ErrorMessage = "Please enter correct grade in range of 1 to 11")]
        public int Grade { get; set; }

        [StringLength(20, ErrorMessage = "Teacher firstname can contain max 20 characters")]
        public string TeacherFirstName { get; set; }

        [StringLength(20, ErrorMessage = "Teacher lastname can contain max 20 characters")]
        public string TeacherLastName { get; set; }
    }
}
