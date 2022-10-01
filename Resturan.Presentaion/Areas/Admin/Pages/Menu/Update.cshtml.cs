using Microsoft.AspNetCore.Mvc;
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
    public class UpdateModel : PageModel
    {
        private IApplicationMenuItem _applicationMenu { get; }
        private IApplicationCategory _applicationCategory { get; }
        private IApplicationFoodType _applicationFood { get; }
       [BindProperty] public UpdateViewModel UpdateView { get; set; }
       private UpdateMenuItemDTO updateMenu { get; set; }
        public UpdateModel(IApplicationMenuItem applicationMenu, IApplicationFoodType applicationFood, IApplicationCategory applicationCategory)
        {
            _applicationMenu = applicationMenu;
            _applicationFood = applicationFood;
            _applicationCategory = applicationCategory;
            updateMenu = new();
            UpdateView = new();
        }

        public async Task<IActionResult> OnGet([FromRoute] string id)
        {
            var item = await _applicationMenu.getItem(id);
            if (item != null)
            {
                UpdateView.Id = item.Id!;
                UpdateView.Name=item.Name;
                UpdateView.Price = item.Price;
                UpdateView.ImagePath = item.Image;
                UpdateView.Description = item.Descriptaion;
                var seletcCategory = await _applicationCategory.GetNameCategories();
                UpdateView.CategorySelectItems = seletcCategory.Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.GUID
                    }).ToList();
                var selectFood = await _applicationFood.GetTypesFood();
                UpdateView.FoodTypeSelectItems = selectFood.Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id
                    }).ToList();
                if (UpdateView.CategorySelectItems.Count == 0 || UpdateView.FoodTypeSelectItems.Count == 0)
                {
                    TempData["Error"] = $"{ErrorMessagesResource.CategoryOrFoodTypeNull}";
                    return RedirectToPage("./Index");
                }

                return Page();
            }
            TempData["Error"] = $"Item Menu {ErrorMessagesResource.NotFound}";
            return RedirectToPage("./Index"); }
        public async Task<IActionResult> OnPost([FromServices] IWebHostEnvironment _environment)
        {

            if (!ModelState.IsValid)
            {
                UpdateView.CategorySelectItems = _applicationCategory.GetNameCategories().Result.Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.GUID
                    }).ToList();
                UpdateView.FoodTypeSelectItems = _applicationFood.GetTypesFood().Result.Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id
                    }).ToList();
                return Page();
            }
            var pathImage = await UploadImage.Send(UpdateView.Image!, "MenuItem", _environment.WebRootPath);
            updateMenu.Name = UpdateView.Name;
            updateMenu.CategoryName = UpdateView.CategoryId;
            updateMenu.Descriptaion = UpdateView.Description;
            updateMenu.FoodTypeName = UpdateView.FoodTypeId;
            updateMenu.Image = pathImage;
            updateMenu.Price = UpdateView.Price;
            updateMenu.Id = UpdateView.Id!;
            var result =  await _applicationMenu.UpdateItem(updateMenu);
            if(result) TempData["success"] = $"Menu Item {ErrorMessagesResource.EditedSuccessfully}";
            else
                TempData["success"] = $"Menu Item {ErrorMessagesResource.EditedUnuccessfully}";
            return RedirectToPage("./Index");
        }
    }

}
