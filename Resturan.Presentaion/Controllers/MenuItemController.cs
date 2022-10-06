using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using NuGet.Protocol;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.MenuItem;

namespace Resturan.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private IApplicationMenuItem _applicationMenu { get; }

        public MenuItemController(IApplicationMenuItem applicationMenu)
        {
            _applicationMenu = applicationMenu;
        }

        [HttpGet]
        public async Task<bool> Delete([FromQuery] string id)
        {
            if (id == null) return false;
            var result = await _applicationMenu.DeleteItem(new DeleteMenuItemDTO
            {
                GUId = id
            });
            return result;
        }
    }
}
