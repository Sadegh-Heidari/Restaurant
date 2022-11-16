using System.ComponentModel.DataAnnotations;
using Restaurant.MainApp.Infrastructure.Tools.Resource;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.FoodType.ViewModel
{
    public class CreatViewModelFoodType:IDisposable
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "NameRequired")]
        public virtual string? Name { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
