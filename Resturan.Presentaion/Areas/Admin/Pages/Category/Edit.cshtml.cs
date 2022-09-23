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
    public EditModel(IApplicationCategory applicationCategory )
    {
        _applicationCategory = applicationCategory;
        Editmodel = new EditViewModelCategory();
    }

    [BindProperty] public EditViewModelCategory Editmodel { get; set; }

    private IApplicationCategory _applicationCategory { get; }

    public IActionResult OnGet([FromRoute(Name = "Id")] string id)
    {
       
        Editmodel.Id = id;
        return Page();
    }

    public async Task<IActionResult> OnPost([FromServices] UpdateCategoryDTO updateCategory)
    {
            updateCategory.GUID = Editmodel.Id;
            updateCategory.Name = Editmodel.Name;
            updateCategory.DisplayOrder = Editmodel.DisplayOrder;
            await _applicationCategory.Update(updateCategory);
            TempData["success"] = "Category Edited successfully";
            return RedirectToPage("./Index");
            
        
    }
}