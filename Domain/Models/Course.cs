using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Course : BaseEntity
    {
        [StringLength(3)]
        public string CourseCode { get; set; }

        [StringLength(30)]
        public string CourseName { get; set; }

        public int Grade { get; set; }

        [StringLength(20)]
        public string TeacherFirstName { get; set; }

        [StringLength(20)]
        public string TeacherLastName { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
