using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Exam : BaseEntity
    {
        [ForeignKey("Course")]
        public string CourseCode { get; set; }

        [ForeignKey("Student")]
        public int StudentNumber { get; set; }

        public DateTime ExamDate { get; set; }

        public int Score { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
