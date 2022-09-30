using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.FoodType;

namespace Resturan.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodTypeController : ControllerBase
    {
        private IApplicationFoodType _applicationFood { get; }

        public FoodTypeController(IApplicationFoodType applicationFood)
        {
            _applicationFood = applicationFood;
        }

        [HttpGet]
        public async Task<bool> Delete([FromQuery] string id)
        {
            var result = await _applicationFood.Update(new DeleteFoodTypeDTO
            {
                Id = id
            });
            return result;
        }
        [HttpGet]
        public async Task<bool> Active([FromQuery] string id)
        {
            var result = await _applicationFood.Update(new ActiveFoodTypeDTO
            {
                Id = id
            });
            return result;
        }
    }
}
