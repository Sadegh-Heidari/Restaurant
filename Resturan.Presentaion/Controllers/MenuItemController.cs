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
        public async Task<string> Get([FromRoute(Name = "page")] int page = 1, [FromRoute(Name = "pagesize")] int pagesize = 10)
            {
            ////var item = await _applicationMenu.GetAllItems(page,pagesize);
            //var x = item.ToJson();
            return null;
        }
    }
}
