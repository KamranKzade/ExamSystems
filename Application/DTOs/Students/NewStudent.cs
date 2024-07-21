using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Students
{
    public class NewStudent
    {
        [Required]
        [Range(1, 99999, ErrorMessage ="Please enter unique number in range of 1 to 99999")]
        public int StudentNumber { get; set; }

        [Required]
        [StringLength(30,ErrorMessage ="Firstname can contain max 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Lastname can contain max 30 characters")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 11, ErrorMessage = "Please enter correct grade in range of 1 to 11")]
        public int Grade { get; set; }
    }
}
