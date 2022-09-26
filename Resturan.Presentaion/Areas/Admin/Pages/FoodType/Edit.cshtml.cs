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
        private IApplicationFoodType _applicationFood { get; }
        public EditModel(IApplicationFoodType applicationFood)
        {
            this._applicationFood = applicationFood;
            foodModel = new();
            foodType = new();
        }

        public async Task<IActionResult> OnGet([FromRoute(Name = "Id")] string id)
        {
            var dto = await _applicationFood.GetFoodTypeById(id);
            if (dto != null)
            {
                foodModel!.Id = dto.Id!;
                foodModel.Name = dto.Name;
                return Page();
            }
            TempData["Error"] = "Food Type Is Not Found";
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPost()
        {
            foodType.Id = foodModel!.Id;
            foodType.Name = foodModel.Name;
            var result = await _applicationFood.Update(foodType);
            if (result == true)
                TempData["success"] = "Food Type Edited successfully";
            else
            {
                TempData["Error"] = "Food Type Edited Unsuccessfully";
            }
            return RedirectToPage("./Index");


        }
    }
}
