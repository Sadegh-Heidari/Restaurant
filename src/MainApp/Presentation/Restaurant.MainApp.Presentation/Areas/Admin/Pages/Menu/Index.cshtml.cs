using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Menu
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        public Pageniation pagemodel { get; set; }
        private IApplicationMenuItem _applicationMenu { get; }

        public IndexModel(IApplicationMenuItem applicationMenu)
        {
            _applicationMenu = applicationMenu;
        }

        public async Task OnGet([FromQuery] int PageSize = 1, [FromQuery] int PageNumber=10)
        {
            pagemodel = await _applicationMenu.GetAllItems(new Pageniation
            {
                PageSize = PageSize,
                PageNumber = PageNumber,
            });
        }
    }
}
