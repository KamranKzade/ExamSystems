using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Students
{
    public class UpdateStudent
    {
        [Required]
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Firstname can contain max 30 characters")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "Lastname can contain max 30 characters")]
        public string LastName { get; set; }

        [Range(1, 11, ErrorMessage = "Please enter correct grade in range of 1 to 11")]
        public int Grade { get; set; }
    }
}
