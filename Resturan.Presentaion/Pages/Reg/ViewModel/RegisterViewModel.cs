using System.ComponentModel.DataAnnotations;

namespace Resturan.Presentation.Pages.Reg.ViewModel
{
    public class RegisterViewModel
    {
        
        [Display(Name = "Name")]
        [Required]
        public string? UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        public bool IsPersistent { get; set; } = false;
    }
}
