using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;

namespace Resturan.Presentation.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private IApplicationCategory _ApplicationCategory { get; }
        public IndexModel(IApplicationCategory applicationCategory)
        {
            _ApplicationCategory = applicationCategory;
        }

        public async Task OnGet()
        {
            
        }
    }
}