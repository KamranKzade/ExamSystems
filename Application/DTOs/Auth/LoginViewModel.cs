using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your Email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
