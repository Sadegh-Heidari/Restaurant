using System.Linq.Expressions;
using Restaurant.MainApp.Core.Domain.Order;

namespace Restaurant.MainApp.Core.Domain.Services
{
    public interface IRepositoryOrderHeader:IRepositoryBase<OrderHeaderModel>
    {
        Task<OrderHeaderModel?> GetOrderHeaderAsync(Expression<Func<OrderHeaderModel,bool>> where,bool AsNoTracker = false);
    }
}
