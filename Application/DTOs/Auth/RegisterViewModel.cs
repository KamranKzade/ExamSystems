using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Firstname")]
        [MinLength(5)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your Firstname")]
        [MinLength(5)]
        public string Lastname { get; set; }
     
        [Required(ErrorMessage = "This field must be filled")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
