using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    [ValidationModelState]

    public class CreatModel : PageModel
    {
        [BindProperty] public CreatViewModelFoodType? Foodmodel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromServices] IApplicationFoodType _applicationFood, [FromServices] CreatFoodTypeDTO creatFood)
        {
           
                creatFood.Name = Foodmodel!.Name;
                await _applicationFood.Add(creatFood);
                TempData["success"] = "Type created successfully";
                return RedirectToPage("./Index");
           

            
        }
    }
}
