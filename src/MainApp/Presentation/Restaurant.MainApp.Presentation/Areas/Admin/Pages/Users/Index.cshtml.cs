using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.UsersApp.Core.Application.Services.DTO;
using Restaurant.UsersApp.Core.Application.Services.Services;

namespace Restaurant.MainApp.Presentation.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private IUserApplication _user { get; }
        public PagenitionDto users { get; set; }
        public IndexModel(IUserApplication user)
        {
            _user = user;
        }

        public async Task OnGet([FromQuery(Name = "PageNumber")] int page = 1, [FromQuery(Name = "PageSize")] int pagesiza = 50)
        {
            users = await _user.GetUsers(new PagenitionDto
            {
                PageNumber = page,
                PageSize = pagesiza
            });
        }
    }
}
