using Acc.Services.DTO;

namespace Acc.Services.Services
{
    public interface IUserApplication:IDisposable
    {
        Task<IOperationValue> CreatUserAsync(UserDTO userDTO);
        Task<IOperationValue> AddRoleUserAsync(UserDTO userDTO,string RoleName);
        Task<UserDTO?> FindUserByIdAsync(UserDTO userDTO);
        Task<IEnumerable<Role>> GetUserRole(UserDTO userDto);
        Task<UserDTO?> FindUserByEmailAsync(UserDTO userDto);
        Task<UserDTO?> FindUserByPhoneNumberAsync(UserDTO userDto);
        Task<IOperationValue> IsUserExist(UserDTO userDto);
        Task<Pagenition> GetUsers(Pagenition pg);
        Task<IOperationValue> DeleteUser(UserDTO userDTO);
    }
}
