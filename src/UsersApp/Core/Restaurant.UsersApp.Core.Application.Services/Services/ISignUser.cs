using Restaurant.UsersApp.Core.Application.Services.DTO;

namespace Restaurant.UsersApp.Core.Application.Services.Services
{
    public interface ISignUser:IDisposable
    {
        Task<IOperationValue> SignInAsync(UserDTO userDTO, bool IsPersistent = false);
        Task<IOperationValue> SignInWithPasswordAsync(UserDTO userDto, string Password, bool IsPersistent = false);
        void SignOutAsync();
    }
}
