using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Exams
{
    public class UpdateExam
    {
        [Required]
        public int Id { get; set; }

        [StringLength(3, ErrorMessage = "Course code can contain only 3 characters")]
        public string CourseCode { get; set; }

        [Range(1, 99999, ErrorMessage = "Please enter unique number in range of 1 to 99999")]
        public int StudentNumber { get; set; }

        public DateTime ExamDate { get; set; }

        [Range(1, 5, ErrorMessage = "Please enter number in range of 1 to 5")]
        public int Score { get; set; }
    }
}
