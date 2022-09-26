using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Infrastructure.Tools.Resource;
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
        if (dto != null)
        {
            Editmodel.Id = dto!.GUID;
            Editmodel.Name = dto.Name;
            Editmodel.DisplayOrder = dto.DisplayOrder;
            return Page();
        }

        TempData["Error"] = $"Category {ErrorMessagesResource.NotFound}";
        return RedirectToPage("./Index");
    }

    public async Task<IActionResult> OnPost()
    {
        updateCategory.GUID = Editmodel.Id;
        updateCategory.Name = Editmodel.Name;
        updateCategory.DisplayOrder = Editmodel.DisplayOrder;
        var result = await _applicationCategory.Update(updateCategory);
        if (result == true)
            TempData["success"] = $"Category {ErrorMessagesResource.EditedSuccessfully}";
        else
        {
            TempData["Error"] = $"Category {ErrorMessagesResource.EditedUnuccessfully}";
        }
        return RedirectToPage("./Index");


    }
}