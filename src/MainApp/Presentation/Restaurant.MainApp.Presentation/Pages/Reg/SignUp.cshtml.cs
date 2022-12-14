using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Presentation.Pages.Reg.ViewModel;
using Restaurant.UsersApp.Core.Application.Services.DTO;
using Restaurant.UsersApp.Core.Application.Services.Services;
using Restaurant.UsersApp.Infrastructure.Autnen;

namespace Restaurant.MainApp.Presentation.Pages.Reg
{
    public class SignUpModel : PageModel
    {
        [BindProperty]public RegisterViewModel RegisterView { get; set; }
        private UserDTO _user { get; set; }
        private IUserApplication _userApplication { get; }
        private ISignUser _signUser { get; }

        public SignUpModel(IUserApplication userApplication, ISignUser signUser)
        {
            _user = new();
            _userApplication = userApplication;
            _signUser = signUser;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _user.UserName = RegisterView.UserName;
            _user.PhoneNumber = RegisterView.PhoneNumber;
            _user.Email = RegisterView.Email;
            _user.Password = RegisterView.Password;
            var result = await _userApplication.CreatUserAsync(_user);
            if (!result.IsSucessed)
            {
                TempData["AuthenError"] = result.ResultMessage;
                return Page();
            }
            var ress = await _signUser.SignInAsync(_user, RegisterView.IsPersistent);
            if (!ress.IsSucessed)
            {
                TempData["AuthenError"] = ress.ResultMessage;
                return Page();
            }
            return RedirectToPage("/Customer/Home/Index");
           
        }

       
    }
}
