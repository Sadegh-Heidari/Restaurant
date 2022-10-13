using Acc.Domain.Models;
using System.Linq.Expressions;
namespace Acc.Domain.Services
{
    public interface IUserAccRepository : IAccRepositoryeBase<Users>
    {
        Task<Users?> FindUserAsync(Expression<Func<Users, bool>> where);
        Task<bool> IsExistUserAsync(Expression<Func<Users, bool>> where);
        Task<T?> FindUserAsync<T>(Expression<Func<Users, bool>> where,Expression<Func<Users,T>> select);

    }
}
