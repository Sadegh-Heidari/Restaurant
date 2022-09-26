using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Infrastructure.Tools.Resource;
using Resturan.Presentation.Filters;

namespace Resturan.Presentation.Areas.Admin.Pages.Category
{
    [ValidationModelState]
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

        public async Task<RedirectToPageResult> OnGetDelete([FromQuery] string id)
        {
            var result = await _applicationCategory.Update(new DeleteCategoryDTO
            {
                GUID = id
            });
            if (result)
                TempData["success"] = $"Category {ErrorMessagesResource.DeletedSuccessfully}";
            else
                TempData["Error"] = $"Category {ErrorMessagesResource.DeletedUnuccessfully}";
            return RedirectToPage("./Index");
        }

        public async Task<RedirectToPageResult> OnGetActive([FromQuery] string id)
        {
            var result = await _applicationCategory.Update(new ActiveCategoryDTO
            {
                GUID = id
            });
            if (result)
                TempData["success"] = $"Category {ErrorMessagesResource.ActivatedSuccessfully}";
            else
                TempData["Error"] = $"Category {ErrorMessagesResource.ActivatedUnsuccessfully}";
            return RedirectToPage("./Index");
        }
    }
}
