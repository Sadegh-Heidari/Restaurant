using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.MenuItem;
using Resturan.Presentation.Areas.Admin.Pages.Menu.ViewModel;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Tools;

namespace Resturan.Presentation.Areas.Admin.Pages.Menu
{
    [ValidationModelState]
    public class CreatModel : PageModel
    {
        [BindProperty] public CreatViewModel CreatView { get; set; }

   
        public CreatModel()
        {
            CreatView = new();
        }

        public void OnGet([FromServices] IApplicationCategory _applicationCategory, [FromServices] IApplicationFoodType _applicationFood)
        {
            CreatView.CategorySelectItems = _applicationCategory.GetNameCategories().Result.Select(x =>
                new SelectListItem
                {
                    Text = x.Name,
                    Value = x.GUID
                }).ToList();
            CreatView.FoodTypeSelectItems = _applicationFood.GetTypesFood().Result.Select(x =>
                new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                }).ToList();
        }

        public async Task<RedirectToPageResult> OnPost([FromServices] IWebHostEnvironment _environment, [FromServices] IApplicationMenuItem _applicationMenu)
        {
            var pathImage = await UploadImage.Send(CreatView.Image!, "MenuItem",_environment.WebRootPath);
            CreatMenuItem dto = new()
            {
                Name = CreatView.Name,
                Category = CreatView.CategoryId,
                Descriptaion = CreatView.Description,
                FoodType = CreatView.FoodTypeId,
                Image = pathImage,
                Price = CreatView.Price,

            };
            await _applicationMenu.AddItem(dto);
            TempData["success"] = "Menu Item Created Successfully";
            return RedirectToPage("./Index");
        }
    }
}
