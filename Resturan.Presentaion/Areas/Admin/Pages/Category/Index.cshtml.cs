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
        public Pageniation Category { get; set; }
        private IApplicationCategory _applicationCategory { get; }
        public IndexModel(IApplicationCategory applicationCategory)
        {
            _applicationCategory = applicationCategory;
        }

        public async Task OnGet([FromQuery(Name = "PageNumber")]int page = 1, [FromQuery(Name = "PageSize")]int pagesiza=10)
        {
            Category = await _applicationCategory.GetAllCategory(new Pageniation
            {
                page = page,
                pagesize = pagesiza
            });


        }
    }
}
