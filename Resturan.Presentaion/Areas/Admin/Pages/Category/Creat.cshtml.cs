using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.Category;
using Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.Category
{
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
            TempData["success"] = "Category created successfully";
            return RedirectToPage("./Index");


        }
    }
}
