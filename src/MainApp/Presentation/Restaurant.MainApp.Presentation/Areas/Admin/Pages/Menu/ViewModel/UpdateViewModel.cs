using Microsoft.Build.Framework;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Menu.ViewModel
{
    public class UpdateViewModel:CreatViewModel
    {
        [Required]
        public string? Id { get; set; }

    }
}
