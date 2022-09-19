using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;

namespace Resturan.Presentation.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private IApplicationCategory _ApplicationCategory { get; }
        public IndexModel(IApplicationCategory applicationCategory)
        {
            _ApplicationCategory = applicationCategory;
        }

        public async Task OnGet()
        {
            var result = await _ApplicationCategory.GetAllCategory();
        }
    }
}