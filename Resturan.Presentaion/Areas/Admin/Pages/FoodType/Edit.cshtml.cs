using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    public class EditModel : PageModel
    {
        [BindProperty]public EditViewModelFoodType? foodModel { get; set; }
        public EditModel()
        {
            foodModel = new EditViewModelFoodType();
        }

        public IActionResult OnGet([FromRoute(Name = "Id")] string id)
        {
            if(foodModel == null) return BadRequest();
            foodModel!.Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPost([FromServices] IApplicationFoodType applicationFood)
        {
            if (ModelState.IsValid)
            {
                await applicationFood.Update(new UpdateFoodTypeDTO { Id = foodModel!.Id, Name = foodModel.Name });
                TempData["success"] = "Type Edited Successfully";
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
