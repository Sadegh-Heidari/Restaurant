using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.Category;

namespace Resturan.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IApplicationCategory _applicationCategory { get; }

        public CategoryController(IApplicationCategory applicationCategory)
        {
            _applicationCategory = applicationCategory;
        }

        [HttpGet]
        public async Task<bool> Delete([FromQuery] string id)
        {
            if (id == null) return false;
           var result = await _applicationCategory.Update(new DeleteCategoryDTO()
            {
                GUID = id
            });
           return result;
        }

        public async Task<bool> Active([FromQuery] string id)
        {
            if (id == null) return false;
            var result = await _applicationCategory.Update(new ActiveCategoryDTO
            {
                GUID = id
            });
            return result;
        }
    }
}
