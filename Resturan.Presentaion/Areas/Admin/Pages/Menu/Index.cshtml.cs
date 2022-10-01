using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using System.Drawing.Printing;

namespace Resturan.Presentation.Areas.Admin.Pages.Menu
{
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
