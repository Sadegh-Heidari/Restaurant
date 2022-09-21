using System.ComponentModel.DataAnnotations;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel
{
    public class CreatViewModel:IDisposable
    {
        [Required]
        public virtual string? Name { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
