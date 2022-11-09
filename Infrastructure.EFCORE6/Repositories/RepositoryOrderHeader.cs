using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Order;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
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
