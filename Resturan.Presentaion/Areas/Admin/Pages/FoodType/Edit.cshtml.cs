using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    [ValidationModelState]

    public class EditModel : PageModel
    {
        [BindProperty] public EditViewModelFoodType? foodModel { get; set; }
        private UpdateFoodTypeDTO foodType { get; set; }
        public EditModel()
        {
            foodModel = new();
            foodType = new();
        }

        public IActionResult OnGet([FromRoute(Name = "Id")] string id)
        {
            foodModel!.Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPost([FromServices] IApplicationFoodType applicationFood)
        {
            foodType.Id = foodModel!.Id;
            foodType.Name = foodModel.Name;
            await applicationFood.Update(foodType);
            TempData["success"] = "Type Edited Successfully";
            return RedirectToPage("./Index");


        }
    }
}
