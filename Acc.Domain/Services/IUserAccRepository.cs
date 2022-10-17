using Acc.Domain.Models;
using System.Linq.Expressions;
namespace Acc.Domain.Services
{
    public interface IUserAccRepository : IAccRepositoryeBase<Users>
    {
        Task<Users?> FindUserAsync(Expression<Func<Users, bool>> where, bool AsNoTracking = false);
        Task<bool> IsExistUserAsync(Expression<Func<Users, bool>> where);
        Task<T?> FindUserAsync<T>(Expression<Func<Users, bool>> where,Expression<Func<Users,T>> select,bool AsNoTracking=false);
        Task<IEnumerable<T>> GetUsers<T>(Expression<Func<Users, T>> select, int page, int pagesize,Expression<Func<Users,bool>> where);


    }
}
