using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel
{
    public class CreatViewModelCategory:IDisposable
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be in range of 1-100!!!")]
        public short DisplayOrder { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
