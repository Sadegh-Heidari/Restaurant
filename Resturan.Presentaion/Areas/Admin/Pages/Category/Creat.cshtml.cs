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
       [BindProperty] public CreatViewModel CreatviewModel { get; set; }
        private IApplicationCategory _applicationCategory { get; }
        private CreatCategoryDTO _categoryDTO { get; set; }
        public CreatModel(IApplicationCategory applicationCategory, CreatCategoryDTO categoryDto)
        {
            _applicationCategory = applicationCategory;
            _categoryDTO = categoryDto;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _categoryDTO.Name = CreatviewModel.Name;
                _categoryDTO.DisplayOrder = CreatviewModel.DisplayOrder;
                await _applicationCategory.Add(_categoryDTO);
                TempData["success"] = "Category created successfully";
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
