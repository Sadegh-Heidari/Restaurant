using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.Category;
[ValidationModelState]

public class EditModel : PageModel
{
    [BindProperty] public EditViewModelCategory Editmodel { get; set; }
    private UpdateCategoryDTO updateCategory { get; set; }
    private IApplicationCategory _applicationCategory { get; }
    public EditModel(IApplicationCategory applicationCategory)
    {
        _applicationCategory = applicationCategory;
        updateCategory = new();
        Editmodel = new();
    }

    public async Task<IActionResult> OnGet([FromRoute(Name = "Id")] string id)
    {

        var dto = await _applicationCategory.GetCategoryById(id);
        Editmodel.Id = dto!.GUID;
        Editmodel.Name = dto.Name;
        Editmodel.DisplayOrder = dto.DisplayOrder;
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        updateCategory.GUID = Editmodel.Id;
        updateCategory.Name = Editmodel.Name;
        updateCategory.DisplayOrder = Editmodel.DisplayOrder;
        await _applicationCategory.Update(updateCategory);
        TempData["success"] = "Category Edited successfully";
        return RedirectToPage("./Index");


    }
}