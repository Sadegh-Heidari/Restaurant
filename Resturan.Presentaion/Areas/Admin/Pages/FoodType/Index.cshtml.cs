using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Infrastructure.Tools.Resource;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{

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
