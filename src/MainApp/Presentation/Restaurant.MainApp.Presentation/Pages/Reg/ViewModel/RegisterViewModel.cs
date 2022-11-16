using System.ComponentModel.DataAnnotations;

namespace Restaurant.MainApp.Presentation.Pages.Reg.ViewModel
{
    public class RegisterViewModel:IDisposable
    {
        
        [Display(Name = "Name")]
        [Required]
        public string? UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        
        [DataType(DataType.PhoneNumber,ErrorMessage = "Entered phone format is not valid.")]    
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
