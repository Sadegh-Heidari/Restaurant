using System.ComponentModel.DataAnnotations;
using System.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturan.Infrastructure.Tools.Resource;
using Resturan.Infrastructure.Tools.Tools;

namespace Resturan.Presentation.Areas.Admin.Pages.Menu.ViewModel
{
    public class CreatViewModel:IDisposable
    {

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "NameRequired")] 
        public  string? Name { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource), ErrorMessageResourceName = "DescriptionRequired")] 
        public  string? Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource), ErrorMessageResourceName = "ImageRequired")]
        [MaxSizeFile(3*1024*1024,ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "MaxSizeFile")]
        [FileExtension(ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "FileExtension")]
        public  IFormFile? Image { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource), ErrorMessageResourceName = "PriceRequired")]
        [Range(1, 1000, ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "PriceRange")]
        public string? Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource), ErrorMessageResourceName = "FoodTypeIdRequired")]
        [Display(Name = "Food Type")] 
        public  string? FoodTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource), ErrorMessageResourceName = "CategoryIdRequired")]
        [Display(Name = "Category")]
        public  string? CategoryId { get; set; }


        public List<SelectListItem>? FoodTypeSelectItems { get; set; }
        public List<SelectListItem>? CategorySelectItems { get; set; }
        public string? Base64Img { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
