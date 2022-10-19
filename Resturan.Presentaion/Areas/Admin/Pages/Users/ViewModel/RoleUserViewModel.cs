using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Resturan.Presentation.Areas.Admin.Pages.Users.ViewModel
{
    public class RoleUserViewModel:IDisposable
    {
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? RoleValue { get; set; }
        public IEnumerable<SelectListItem>? RoleItem { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
