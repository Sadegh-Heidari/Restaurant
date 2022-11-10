using Acc.Services.DTO;
using Acc.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Resturan.Presentation.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private IUserApplication _user { get; }
        public Pagenition users { get; set; }
        public IndexModel(IUserApplication user)
        {
            _user = user;
        }

        public async Task OnGet([FromQuery(Name = "PageNumber")] int page = 1, [FromQuery(Name = "PageSize")] int pagesiza = 50)
        {
            users = await _user.GetUsers(new Pagenition
            {
                PageNumber = page,
                PageSize = pagesiza
            });
        }
    }
}
