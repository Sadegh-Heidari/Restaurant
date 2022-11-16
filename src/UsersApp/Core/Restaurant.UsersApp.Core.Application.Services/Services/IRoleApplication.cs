using Restaurant.UsersApp.Core.Application.Services.DTO;

namespace Restaurant.UsersApp.Core.Application.Services.Services
{
    public interface IRoleApplication : IDisposable
    {
        Task<IOperationValue> CreatRole(RoleDto roleDto);
        Task<IEnumerable<RoleDto>> GetRoles();
    }
}
