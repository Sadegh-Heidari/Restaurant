using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;

namespace Acc.Domain.Services
{
    public interface IAccUserRoleRepository
    {
        Task<bool> IsExistUserRoleAsync(UserRole userRole);
        Task<bool> AddUserRoleAsync(UserRole userRole);
    }
}
