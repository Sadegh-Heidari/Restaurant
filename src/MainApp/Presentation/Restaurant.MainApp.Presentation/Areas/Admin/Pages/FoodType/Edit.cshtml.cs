using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.FoodType;
using Restaurant.MainApp.Infrastructure.Tools.Resource;
using Restaurant.MainApp.Presentation.Areas.Admin.Pages.FoodType.ViewModel;
using Restaurant.MainApp.Presentation.Filters;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.FoodType
{
    [Authorize(Roles = "Admin")]

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
            TempData["Error"] = $"Food Type {ErrorMessagesResource.NotFound}";
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPost()
        {
            foodType.Id = foodModel!.Id;
            foodType.Name = foodModel.Name;
            var result = await _applicationFood.Update(foodType);
            if (result == true)
                TempData["success"] = $"Food Type {ErrorMessagesResource.EditedSuccessfully}";
            else
            {
                TempData["Error"] = $"Food Type {ErrorMessagesResource.EditedUnuccessfully}";
            }
            return RedirectToPage("./Index");


        }
    }
}
