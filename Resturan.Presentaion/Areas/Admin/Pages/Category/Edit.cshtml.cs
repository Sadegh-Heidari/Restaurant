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
    public EditModel( )
    {
        updateCategory = new();
        Editmodel = new ();
    }


    public IActionResult OnGet([FromRoute(Name = "Id")] string id)
    {
       
        Editmodel.Id = id;
        return Page();
    }

    public async Task<IActionResult> OnPost([FromServices] IApplicationCategory _applicationCategory)
    {
            updateCategory.GUID = Editmodel.Id;
            updateCategory.Name = Editmodel.Name;
            updateCategory.DisplayOrder = Editmodel.DisplayOrder;
            await _applicationCategory.Update(updateCategory);
            TempData["success"] = "Category Edited successfully";
            return RedirectToPage("./Index");
            
        
    }
}