using Acc.Domain.Models;
using System.Linq.Expressions;
namespace Acc.Domain.Services
{
    public interface IRoleAccRepository:IAccRepositoryeBase<Role>
    {
        Task<Role?> FindRoleAsync(Expression<Func<Role, bool>> where, bool AsNoTracking = false);
        Task<bool> IsExistRole(Expression<Func<Role, bool>> where);
    }
}
