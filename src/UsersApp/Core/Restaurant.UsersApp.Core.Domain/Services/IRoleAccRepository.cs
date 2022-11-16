using System.Linq.Expressions;
using Restaurant.UsersApp.Core.Domain.Models;

namespace Restaurant.UsersApp.Core.Domain.Services
{
    public interface IRoleAccRepository:IAccRepositoryeBase<Role>
    {
        Task<Role?> FindRoleAsync(Expression<Func<Role, bool>> where, bool AsNoTracking = false);
        Task<bool> IsExistRole(Expression<Func<Role, bool>> where);
        Task<IEnumerable<T?>> GetAllRole<T>(Expression<Func<Role,T>> select, bool AsNoTracking = false);
    }
}
