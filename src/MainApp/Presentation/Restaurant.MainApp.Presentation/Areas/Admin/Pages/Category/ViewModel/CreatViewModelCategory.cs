using System.ComponentModel.DataAnnotations;
using Restaurant.MainApp.Infrastructure.Tools.Resource;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Category.ViewModel
{
    public class CreatViewModelCategory:IDisposable
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "NameRequired")]
        public string? Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource), ErrorMessageResourceName = "DisplayOrderRequired")]
        [Display(Name = "Display Order")]
        [Range(1, 100,ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "DisplayRang")]
        public short DisplayOrder { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
