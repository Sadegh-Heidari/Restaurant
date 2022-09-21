using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.Category
{
    public class CreatModel : PageModel
    {
       [BindProperty] public CreatViewModel? CreatviewModel { get; set; }
        private IApplicationCategory ApplicationCat { get; }
        private CreatCategoryDTO Categorydto { get; set; }
        public CreatModel(IApplicationCategory applicationCat, CreatCategoryDTO categorydto)
        {
            this.ApplicationCat = applicationCat;
            Categorydto = categorydto;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Categorydto.Name = CreatviewModel!.Name;
                Categorydto.DisplayOrder = CreatviewModel.DisplayOrder;
                await ApplicationCat.Add(Categorydto);
                TempData["success"] = "Category created successfully";
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
