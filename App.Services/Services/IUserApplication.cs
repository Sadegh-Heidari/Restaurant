using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Services.DTO;

namespace Acc.Services.Services
{
    public interface IUserApplication
    {
        Task<bool> CreatUserAsync(CreatUser userDTO);
        Task<bool> AddRoleUserAsync(UserDTO userDTO,string RoleName);
        Task<UserDTO?> FindUserAsync(UserDTO userDTO);

    }
}
