using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    [ValidationModelState]

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

        public async Task<IActionResult> OnGetDelete([FromQuery(Name = "Id")] string id)
        {
           

            
                await _applicationFood.Update(new DeleteFoodTypeDTO()
                {
                    Id = id
                });
                TempData["success"] = "Type Deleted successfully";
                return RedirectToPage("./Index");
            

        }
        public async Task<RedirectToPageResult> OnGetActive([FromQuery] string id)
        {
            await _applicationFood.Update(new ActiveFoodTypeDTO()
            {
                Id = id
            });
            TempData["success"] = "Type Activated successfully";
            return RedirectToPage("./Index");
        }
    }
}