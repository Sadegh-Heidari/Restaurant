using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;

namespace Resturan.Presentation.Areas.Admin.Pages.Category
{
    public class IndexModel : PageModel
    {
        public IEnumerable<CategoryDTO> Category { get; set; }
        private IApplicationCategory _applicationCategory { get; }
        public IndexModel(IApplicationCategory applicationCategory)
        {
            _applicationCategory = applicationCategory;
            Category = new List<CategoryDTO>();
        }

        public async Task OnGet()
        {
            Category = await _applicationCategory.GetAllCategory();
        }

        public async Task<IActionResult> OnGetDelete([FromQuery] string id)
        {
           await _applicationCategory.Delete(new DeleteCategoryDTO
            {
                GUID = id
            });
           TempData["success"] = "Category Edited successfully";
           return RedirectToPage("./Index");
        }
    }
}
