using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;

namespace Acc.Domain.Services
{
    public interface IAccUserRoleRepository
    {
        Task<bool> IsExistUserRoleAsync(UserRole userRole);
        Task<bool> AddUserRoleAsync(UserRole userRole);
        Task<IEnumerable<T>> GetUserRole<T>(Expression<Func<UserRole, T>> select,
            Expression<Func<UserRole, bool>> where);
    }
}
