using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public int StudentNumber { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        public int Grade { get; set; }

        public ICollection<Exam> Exams { get; set; }
    }
}
