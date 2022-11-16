using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem;
using Restaurant.MainApp.Infrastructure.Tools.Resource;
using Restaurant.MainApp.Infrastructure.Tools.Tools;
using Restaurant.MainApp.Presentation.Areas.Admin.Pages.Menu.ViewModel;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Menu
{
    [Authorize(Roles = "Admin")]

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
        public async Task<IActionResult> OnGet()
        {
            var seletcCategory = await _applicationCategory.GetNameCategories();
            CreatView.CategorySelectItems = seletcCategory.Select(x =>
                new SelectListItem
                {
                    Text = x.Name,
                    Value = x.GUID
                }).ToList();
            var selectFood = await _applicationFood.GetTypesFood();
            CreatView.FoodTypeSelectItems = selectFood.Select(x =>
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
                if (CreatView.Image != null)
                    CreatView.ImagePath = await UploadImage.Send(CreatView.Image, "MenuItem", _environment.WebRootPath);
                return Page();
            }
            var pathImage = await UploadImage.Send(CreatView.Image!, "MenuItem",_environment.WebRootPath);
            creatMenu.Name = CreatView.Name;
            creatMenu.CategoryName = CreatView.CategoryId;
            creatMenu.Descriptaion = CreatView.Description;
            creatMenu.FoodTypeName = CreatView.FoodTypeId;
            creatMenu.Image = pathImage;
            creatMenu.Price = CreatView.Price.ToString();
            await _applicationMenu.AddItem(creatMenu);
            TempData["success"] = $"Menu Item {ErrorMessagesResource.CreatedSuccessfully}";
            return RedirectToPage("./Index");
        }
    }
}
