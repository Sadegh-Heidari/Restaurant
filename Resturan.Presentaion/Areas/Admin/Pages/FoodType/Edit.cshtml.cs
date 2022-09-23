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
        [BindProperty]public EditViewModelFoodType? foodModel { get; set; }
        public EditModel()
        {
            foodModel = new EditViewModelFoodType();
        }

        public IActionResult OnGet([FromRoute(Name = "Id")] string id)
        {
            foodModel!.Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPost([FromServices] IApplicationFoodType applicationFood)
        {
           
                await applicationFood.Update(new UpdateFoodTypeDTO { Id = foodModel!.Id, Name = foodModel.Name });
                TempData["success"] = "Type Edited Successfully";
                return RedirectToPage("./Index");
           

        }
    }
}
