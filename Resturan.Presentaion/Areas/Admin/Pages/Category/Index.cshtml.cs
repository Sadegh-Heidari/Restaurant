using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Infrastructure.Tools.Resource;
using Resturan.Presentation.Filters;
using X.PagedList;

namespace Resturan.Presentation.Areas.Admin.Pages.Category
{
    [ValidationModelState]
    public class IndexModel : PageModel
    {
        public Pageniation Category { get; set; }
        private IApplicationCategory _applicationCategory { get; }
        public IndexModel(IApplicationCategory applicationCategory)
        {
            _applicationCategory = applicationCategory;
        }

        public async Task OnGet([FromQuery(Name = "PageNumber")]int page = 1, [FromQuery(Name = "PageSize")]int pagesiza=1)
        {
            Category = await _applicationCategory.GetAllCategory(new Pageniation
            {
                page = page,
                pagesize = pagesiza
            });


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
