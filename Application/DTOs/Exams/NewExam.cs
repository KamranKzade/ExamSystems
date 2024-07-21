using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Exams
{
    public class NewExam
    {
        [Required]
        [StringLength(3, ErrorMessage = "Course code can contain only 3 characters")]
        public string CourseCode { get; set; }

        [Required]
        [Range(1, 99999, ErrorMessage = "Please enter unique number in range of 1 to 99999")]
        public int StudentNumber { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }
    }
}
