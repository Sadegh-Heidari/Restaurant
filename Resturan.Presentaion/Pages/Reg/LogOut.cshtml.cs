using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Resturan.Presentation.Pages.Reg
{
    public class LogOutModel : PageModel
    {
        public async Task<RedirectToPageResult> OnGet()
        {
            await HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Customer/Home/Index");
        }
    }
}
