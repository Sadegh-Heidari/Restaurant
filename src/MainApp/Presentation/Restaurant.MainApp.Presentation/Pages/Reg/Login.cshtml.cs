using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Presentation.Pages.Reg.ViewModel;
using Restaurant.UsersApp.Core.Application.Services.DTO;
using Restaurant.UsersApp.Core.Application.Services.Services;
using Restaurant.UsersApp.Infrastructure.Autnen;

namespace Restaurant.MainApp.Presentation.Pages.Reg
{
    public class LoginModel : PageModel
    {
        [BindProperty]public LoginViewModel RegisterView { get; set; }
        private UserDTO _userDTO { get; set; }
        private IUserApplication _userapplication { get; }
        private ISignUser _signUser { get; }
        [FromQuery] public string? ReturnUrl { get; set; } = "/Customer/Home/Index";
        public LoginModel( IUserApplication userapplication, ISignUser signUser)
        {
            _userDTO = new();
            _userapplication = userapplication;
            _signUser = signUser;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (!Url.IsLocalUrl(ReturnUrl)&&ReturnUrl!=null) return RedirectToPage("/Errors/AccessDenied/Access");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userDTO.Email = RegisterView.Email;
            var FindUser = await _userapplication.FindUserByEmailAsync(_userDTO);
            if (FindUser == null)
            {
                TempData["AuthenError"] = "This user is not Exist please Sign Up";
                return Page();
            }
            var result =
                await _signUser.SignInWithPasswordAsync(FindUser, RegisterView.Password!,
                    RegisterView.IsPersistent);
            if (!result.IsSucessed)
            {
                TempData["AuthenError"] = result.ResultMessage;
                return Page();
            }

            return LocalRedirect(ReturnUrl!);
           
        }
    }
}
