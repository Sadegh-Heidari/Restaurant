using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]

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
                PageSize = page,
                PageNumber = pagesiza
            });


        }
    }
}
