using Restaurant.UsersApp.Core.Application.Services.DTO;
using Restaurant.UsersApp.Core.Application.Services.Services;

namespace Restaurant.UsersApp.Infrastructure.Autnen
{
    public interface ISignUser:IDisposable
    {
        Task<IOperationValue> SignInAsync(UserDTO userDTO, bool IsPersistent = false);
        Task<IOperationValue> SignInWithPasswordAsync(UserDTO userDto, string Password, bool IsPersistent = false);
        void SignOutAsync();
    }
}
