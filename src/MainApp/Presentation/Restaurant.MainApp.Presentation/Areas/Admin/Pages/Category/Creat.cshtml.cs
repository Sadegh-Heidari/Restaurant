using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.Category;
using Restaurant.MainApp.Infrastructure.Tools.Resource;
using Restaurant.MainApp.Presentation.Areas.Admin.Pages.Category.ViewModel;
using Restaurant.MainApp.Presentation.Filters;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]
    [ValidationModelState]
    public class CreatModel : PageModel
    {
        [BindProperty] public CreatViewModelCategory? CreatviewModel { get; set; }
        private CreatCategoryDTO Categorydto { get; set; }
        public CreatModel()
        {
            Categorydto = new();
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost([FromServices] IApplicationCategory ApplicationCat)
        {


            Categorydto.Name = CreatviewModel!.Name;
            Categorydto.DisplayOrder = CreatviewModel.DisplayOrder;
            await ApplicationCat.Add(Categorydto);
            TempData["success"] = $"Category {ErrorMessagesResource.CreatedSuccessfully}";
            return RedirectToPage("./Index");


        }
    }
}
