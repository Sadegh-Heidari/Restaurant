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
    public class CreatModel : PageModel
    {
        [BindProperty] public CreatViewModelFoodType? Foodmodel { get; set; }
        private CreatFoodTypeDTO? creatFood { get; set; }

        public CreatModel()
        {
            creatFood = new();
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost([FromServices] IApplicationFoodType _applicationFood)
        {

            creatFood!.Name = Foodmodel!.Name;
            await _applicationFood.Add(creatFood);
            TempData["success"] = $"Type {ErrorMessagesResource.CreatedSuccessfully}";
            return RedirectToPage("./Index");



        }
    }
}
