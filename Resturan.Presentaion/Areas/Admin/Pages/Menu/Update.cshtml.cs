using System.Drawing;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.CompilerServices;
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
        private IWebHostEnvironment _webHostEnvironment { get; }
        [BindProperty] public UpdateViewModel UpdateView { get; set; }
        private UpdateMenuItemDTO updateMenu { get; set; }
        public UpdateModel(IApplicationMenuItem applicationMenu, IApplicationFoodType applicationFood, IApplicationCategory applicationCategory, IWebHostEnvironment webHostEnvironment)
        {
            _applicationMenu = applicationMenu;
            _applicationFood = applicationFood;
            _applicationCategory = applicationCategory;
            _webHostEnvironment = webHostEnvironment;
            updateMenu = new();
            UpdateView = new();
        }

        public async Task<IActionResult> OnGet([FromRoute] string id)
        {
            var item = await _applicationMenu.getItem(id);
            if (item != null)
            {
                UpdateView.Id = item.Id!;
                UpdateView.Name = item.Name;
                UpdateView.Price = item.Price;
                UpdateView.Base64Img = item.Image;
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

                var path = Path.Combine(_webHostEnvironment.WebRootPath, UpdateView.Base64Img!);
                UpdateView.Base64Img = await ConvertImgToBase64String.Base64StringAsync(path);
                return Page();
            }
            TempData["Error"] = $"Item Menu {ErrorMessagesResource.NotFound}";
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPost()
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
                if (UpdateView.Image != null)
                {
                    UpdateView.Base64Img =  ConvertImgToBase64String.Base64StringAsync(UpdateView.Image.OpenReadStream());
                    UpdateView.Image = UpdateView.Image;
                }

                return Page();
            }
            var pathImage = await UploadImage.Send(UpdateView.Image!, "MenuItem", _webHostEnvironment.WebRootPath);
            updateMenu.Name = UpdateView.Name;
            updateMenu.CategoryName = UpdateView.CategoryId;
            updateMenu.Descriptaion = UpdateView.Description;
            updateMenu.FoodTypeName = UpdateView.FoodTypeId;
            updateMenu.Image = pathImage;
            updateMenu.Price = UpdateView.Price;
            updateMenu.Id = UpdateView.Id!;
            var result = await _applicationMenu.UpdateItem(updateMenu);
            if (result) TempData["success"] = $"Menu Item {ErrorMessagesResource.EditedSuccessfully}";
            else
                TempData["success"] = $"Menu Item {ErrorMessagesResource.EditedUnuccessfully}";
            return RedirectToPage("./Index");
        }
    }

}
