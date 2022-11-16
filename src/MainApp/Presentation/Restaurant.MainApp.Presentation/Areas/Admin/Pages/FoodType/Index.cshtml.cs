using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.FoodType
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private IApplicationFoodType _applicationFood { get; }
        public Pageniation FoodTypes { get; set; }
        public IndexModel(IApplicationFoodType applicationFood)
        {
            _applicationFood = applicationFood;
        }

        public async Task OnGet([FromQuery(Name = "PageSize")] int page = 1, [FromQuery(Name = "PageNumber")] int pagesize = 10)
        {
            FoodTypes = await _applicationFood?.GetAllFoodType(new Pageniation
            {
                PageSize = page,
                PageNumber = pagesize
            })!;
        }
    }
}
