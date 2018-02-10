using System.ComponentModel.DataAnnotations;

namespace GetUserIdAsyncNullExample.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Your name / nickname must be between {2} and {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Name / nickname")]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your {0} must be between {2} and {1} characters long.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords you entered do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
