using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Restaurant.MainApp.Core.Domain.Order;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryOrderHeader:RepositoryBase<OrderHeaderModel>,IRepositoryOrderHeader
    {
        public RepositoryOrderHeader(ApplicationContext context) : base(context)
        {
        }

        public async Task<OrderHeaderModel?> GetOrderHeaderAsync(Expression<Func<OrderHeaderModel, bool>> where, bool AsNoTracker = false)
        {
            IQueryable<OrderHeaderModel> query = _context.Set<OrderHeaderModel>();
            if (AsNoTracker == true) query = query.AsNoTracking();
            var result= await query.Where(where).FirstOrDefaultAsync();
            return result;
        }
    }
}
