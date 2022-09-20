using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.Category
{
    public class EditModel : PageModel
    {
        public EditModel(IApplicationCategory applicationCategory, UpdateCategoryDTO updateCategory)
        {
            _applicationCategory = applicationCategory;
            _updateCategory = updateCategory;
        }

       [BindProperty] public  EditViewModel Editmodel { get; set; }
        private static string Guid { get; set; }

        private UpdateCategoryDTO _updateCategory { get; set; }
        private IApplicationCategory _applicationCategory { get; }
        public void OnGet([FromRoute(Name = "Id")] string id)
        {
            Guid = id;

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _updateCategory.GUID=Guid;
                _updateCategory.Name = Editmodel.Name;
                _updateCategory.DisplayOrder = Editmodel.DisplayOrder;
                await _applicationCategory.Update(_updateCategory);
                TempData["success"] = "Category Edited successfully";
                return RedirectToPage("./Index");

            }

            return Page();
        }
    }
}
