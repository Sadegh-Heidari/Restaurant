using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages
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