using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Services.DTO;
using Acc.Services.Services;

namespace Autnen
{
    public interface ISignUser
    {
        Task<IOperationValue> SignInAsync(UserDTO userDTO, bool IsPersistent = false);
        Task<IOperationValue> SignInWithPasswordAsync(UserDTO userDto, string Password, bool IsPersistent = false);
        void SignOutAsync();
    }
}
