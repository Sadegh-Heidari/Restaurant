using Microsoft.AspNetCore.Mvc;
using Restaurant.UsersApp.Core.Application.Services.DTO;
using Restaurant.UsersApp.Core.Application.Services.Services;

namespace Restaurant.MainApp.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserApplication _user { get; }
        private UserDTO _userDTO { get; }
        public UserController(IUserApplication user)
        {
            _user = user;
            _userDTO = new();
        }

        [HttpGet]
        public async Task<bool> Deleteuser([FromQuery] string id)
        {
            if (id == null) return false;
            _userDTO.Id=id;
           var result = await _user.DeleteUser(_userDTO);
           return result.IsSucessed;
        }
    }
}
