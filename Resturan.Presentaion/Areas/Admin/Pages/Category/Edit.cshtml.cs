using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.Category;

public class EditModel : PageModel
{
    public EditModel(IApplicationCategory applicationCategory, UpdateCategoryDTO updateCategory)
    {
        _applicationCategory = applicationCategory;
        _updateCategory = updateCategory;
        Editmodel = new EditViewModel();
    }

    [BindProperty] public EditViewModel Editmodel { get; set; }

    private UpdateCategoryDTO _updateCategory { get; set; }
    private IApplicationCategory _applicationCategory { get; }

    public void OnGet([FromRoute(Name = "Id")] string id)
    {
        Editmodel.Id = id;
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _updateCategory.GUID = Editmodel.Id;
            _updateCategory.Name = Editmodel.Name;
            _updateCategory.DisplayOrder = Editmodel.DisplayOrder;
            await _applicationCategory.Update(_updateCategory);
            TempData["success"] = "Category Edited successfully";
            return RedirectToPage("./Index");
        }

        return Page();
    }
}