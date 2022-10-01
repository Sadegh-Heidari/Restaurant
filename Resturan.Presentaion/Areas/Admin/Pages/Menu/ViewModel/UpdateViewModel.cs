using Microsoft.Build.Framework;

namespace Resturan.Presentation.Areas.Admin.Pages.Menu.ViewModel
{
    public class UpdateViewModel:CreatViewModel
    {
        [Required]
        public string? Id { get; set; }

        public string? ImagePath { get; set; }
    }
}
