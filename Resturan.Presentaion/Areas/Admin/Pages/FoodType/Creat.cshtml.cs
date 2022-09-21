using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    public class CreatModel : PageModel
    {
        [BindProperty]public CreatViewModel? Foodmodel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromServices] IApplicationFoodType _applicationFood)
        {
            if (ModelState.IsValid)
            {
                await _applicationFood.Add(new CreatFoodTypeDTO { Name = Foodmodel!.Name });
                TempData["success"] = "Type created successfully";
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
