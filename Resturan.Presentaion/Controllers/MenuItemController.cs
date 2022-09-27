using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using NuGet.Protocol;
using Resturan.Application.Service.ApplicationServices;

namespace Resturan.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private IApplicationMenuItem _applicationMenu { get; }

        public MenuItemController(IApplicationMenuItem applicationMenu)
        {
            _applicationMenu = applicationMenu;
        }

        [HttpGet]
        public async Task<string> Get()
            {
            var item = await _applicationMenu.GetAllItems();
            var x = item.ToJson();
            return x;
        }
    }
}
