using Microsoft.AspNetCore.Mvc;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.FoodType;

namespace Restaurant.MainApp.Presentation.Controllers
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
            if (id == null) return false;
            var result = await _applicationFood.Update(new DeleteFoodTypeDTO
            {
                Id = id
            });
            return result;
        }
        [HttpGet]
        public async Task<bool> Active([FromQuery] string id)
        {
            if (id == null) return false;
            var result = await _applicationFood.Update(new ActiveFoodTypeDTO
            {
                Id = id
            });
            return result;
        }
    }
}
