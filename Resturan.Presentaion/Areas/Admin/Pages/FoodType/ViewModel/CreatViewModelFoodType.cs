using System.ComponentModel.DataAnnotations;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel
{
    public class CreatViewModelFoodType:IDisposable
    {
        [Required]
        public virtual string? Name { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
