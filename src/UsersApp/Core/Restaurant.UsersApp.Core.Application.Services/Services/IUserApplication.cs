using System.Security.Claims;
using Restaurant.UsersApp.Core.Application.Services.DTO;

namespace Restaurant.UsersApp.Core.Application.Services.Services
{
    public interface IUserApplication:IDisposable
    {
        Task<IOperationValue> CreatUserAsync(UserDTO userDTO);
        Task<IOperationValue> AddRoleUserAsync(UserDTO userDTO,string RoleName);
        Task<UserDTO?> FindUserByIdAsync(UserDTO userDTO);
        Task<IEnumerable<RoleDto>> GetUserRole(UserDTO userDto);
        Task<UserDTO?> FindUserByEmailAsync(UserDTO userDto);
        Task<UserDTO?> FindUserByPhoneNumberAsync(UserDTO userDto);
        Task<IOperationValue> IsUserExist(UserDTO userDto);
        Task<PagenitionDto> GetUsers(PagenitionDto pg);
        Task<IOperationValue> DeleteUser(UserDTO userDTO);
        Task<UserDTO?> FindUserAsync(ClaimsPrincipal claimsPrincipal);
    }
}
