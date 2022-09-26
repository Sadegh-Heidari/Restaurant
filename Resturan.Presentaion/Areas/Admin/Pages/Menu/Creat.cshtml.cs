using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.MenuItem;
using Resturan.Infrastructure.Tools.Resource;
using Resturan.Infrastructure.Tools.Tools;
using Resturan.Presentation.Areas.Admin.Pages.Menu.ViewModel;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.Menu
{
    public class CreatModel : PageModel
    {
        [BindProperty] public CreatViewModel CreatView { get; set; }
        private CreatMenuItem creatMenu { get; set; }
        private IApplicationCategory _applicationCategory { get; }
        private IApplicationFoodType _applicationFood { get; }

        public CreatModel(IApplicationFoodType applicationFood, IApplicationCategory applicationCategory)
        {
            _applicationFood = applicationFood;
            _applicationCategory = applicationCategory;
            CreatView = new();
            creatMenu = new();
        }
        public IActionResult OnGet()
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
            if (CreatView.CategorySelectItems.Count == 0 || CreatView.FoodTypeSelectItems.Count == 0)
            {
                TempData["Error"] = $"{ErrorMessagesResource.CategoryOrFoodTypeNull}";
                return RedirectToPage("./Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPost([FromServices] IWebHostEnvironment _environment, [FromServices] IApplicationMenuItem _applicationMenu)
        {

            if (!ModelState.IsValid)
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
                return Page();
            }
            var pathImage = await UploadImage.Send(CreatView.Image!, "MenuItem",_environment.WebRootPath);
            creatMenu.Name = CreatView.Name;
            creatMenu.Category = CreatView.CategoryId;
            creatMenu.Descriptaion = CreatView.Description;
            creatMenu.FoodType = CreatView.FoodTypeId;
            creatMenu.Image = pathImage;
            creatMenu.Price = CreatView.Price;
            await _applicationMenu.AddItem(creatMenu);
            TempData["success"] = $"Menu Item {ErrorMessagesResource.CreatedSuccessfully}";
            return RedirectToPage("./Index");
        }
    }
}
