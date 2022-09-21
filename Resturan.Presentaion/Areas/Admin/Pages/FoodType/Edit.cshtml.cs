using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Presentation.Areas.Admin.Pages.FoodType.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.FoodType
{
    public class EditModel : PageModel
    {
        public EditViewModelFoodType? foodModel { get; set; }
        public EditModel()
        {
            foodModel = new EditViewModelFoodType();
        }

        public void OnGet([FromRoute(Name = "Id")] string id)
        {
            if(foodModel == null) re
            foodModel!.Id = id;
        }
    }
}
