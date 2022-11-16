using System.Linq.Expressions;
using Restaurant.UsersApp.Core.Domain.Models;

namespace Restaurant.UsersApp.Core.Domain.Services
{
    public interface IAccUserRoleRepository
    {
        Task<bool> IsExistUserRoleAsync(UserRole userRole);
        Task<bool> AddUserRoleAsync(UserRole userRole);
        Task<IEnumerable<T>> GetUserRole<T>(Expression<Func<UserRole, T>> select,
            Expression<Func<UserRole, bool>> where);
        Task<IEnumerable<UserRole>> GetUserRole(Expression<Func<UserRole, bool>> where);
        bool DeleteUserRole(IEnumerable<UserRole> userRoles);
    }
}
