using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.FoodType;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    public class IndexModel : PageModel
    {
        private IApplicationFoodType _applicationFood { get; }
        public IEnumerable<FoodTypeDTO>? FoodTypes { get; set; }
        public IndexModel(IApplicationFoodType applicationFood)
        {
            _applicationFood = applicationFood;
        }

        public async Task OnGet()
        {
            FoodTypes = await _applicationFood?.GetAllFoodType()!;
        }
    }
}
