using Acc.Domain.Models;
using Acc.Services.DTO;
using Acc.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturan.Presentation.Areas.Admin.Pages.Users.ViewModel;

namespace Resturan.Presentation.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class AddRoleModel : PageModel
    {
        private UserDTO userDTO { get; set; }
        private IRoleApplication _role { get; }
        private IUserApplication _user { get; }
       [BindProperty] public RoleUserViewModel Roles { get; set; }
        public AddRoleModel(IRoleApplication role, IUserApplication user)
        {
            _role = role;
            _user = user;
            userDTO = new();
            Roles = new();
        }

        public async Task<IActionResult> OnGet([FromRoute]string id)
        {
            if(id==null) return BadRequest();
            userDTO.Id = id;
            var user = await _user.FindUserByIdAsync(userDTO);
            if(user==null) return BadRequest();
            var role = await _role.GetRoles();
            Roles.RoleItem = role.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            });
            Roles.Email = user.Email;
            Roles.UserName = user.UserName;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var role = await _role.GetRoles();
                Roles.RoleItem = role.Select(x => new SelectListItem
                {
                    Value = x.Name,
                    Text = x.Name
                });
                return Page();
            }

            userDTO.Email = Roles.Email;
            var result = await _user.AddRoleUserAsync(userDTO, Roles.RoleValue!);
            if (!result.IsSucessed)
            {
                var role = await _role.GetRoles();
                Roles.RoleItem = role.Select(x => new SelectListItem
                {
                    Value = x.Name,
                    Text = x.Name
                });
                TempData["ErrorRole"] = result.ResultMessage;
                return Page();
            }

            TempData["success"] = result.ResultMessage;
            return RedirectToPage("./Index");
        }
    }
}
