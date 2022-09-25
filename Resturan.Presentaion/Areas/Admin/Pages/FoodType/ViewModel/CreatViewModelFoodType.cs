using System.ComponentModel.DataAnnotations;
using Resturan.Infrastructure.Tools.Resource;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel
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
