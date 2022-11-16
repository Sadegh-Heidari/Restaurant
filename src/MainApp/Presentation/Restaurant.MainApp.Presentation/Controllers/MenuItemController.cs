using Microsoft.AspNetCore.Mvc;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem;

namespace Restaurant.MainApp.Presentation.Controllers
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
