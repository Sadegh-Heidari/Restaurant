using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Resturan.Presentation.Pages.Customer.Cart.ViewModels
{
	public class SummaryViewModels:IDisposable
	{
        
        [Display(Name = "Pick Up Name")]
        [Required]
        public string? PickupName { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }
        public string? Comments { get; set; }
        [ValidateNever]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Total")]
        public float OrderTotal { get; set; }
        [Display(Name = "Pick Up Time")]
        [Required]
        public DateTime? PickupTime { get; set; }
        [Display(Name = "Pick Up Date")]
        [Required]
        public DateTime PickupDate { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
