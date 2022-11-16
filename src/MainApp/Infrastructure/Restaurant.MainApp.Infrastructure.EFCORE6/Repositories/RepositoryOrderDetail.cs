using Restaurant.MainApp.Core.Domain.OrderDetail;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryOrderDetail:RepositoryBase<OrderDetailModel>,IRepositoryOrderDetail
    {
        public RepositoryOrderDetail(ApplicationContext context) : base(context)
        {
        }
    }
}
