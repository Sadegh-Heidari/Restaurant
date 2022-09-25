using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturan.Presentation.Tools;

namespace Resturan.Presentation.Areas.Admin.Pages.Menu.ViewModel
{
    public class CreatViewModel
    {

        [Required] public  string? Name { get; set; }
        [Required] public  string? Description { get; set; }
        [Required] 
        [MaxSizeFile(3*1024*1024,ErrorMessage = "Please choose a file whose size is less than 3 MB")]
        [FileExtension(ErrorMessage = "File Extension Is Not Valid")]
        public  IFormFile? Image { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Price should be between $1 and $1000")]
        public string? Price { get; set; }
        [Required][Display(Name = "Food Type")] public  string? FoodTypeId { get; set; }
        [Required] [Display(Name = "Category")]public  string? CategoryId { get; set; }
        public List<SelectListItem>? FoodTypeSelectItems { get; set; }
        public List<SelectListItem>? CategorySelectItems { get; set; }
    }
}
