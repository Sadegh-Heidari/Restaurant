using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Order;

namespace Resturan.Domain.Services
{
    public interface IRepositoryOrderHeader:IRepositoryBase<OrderHeaderModel>
    {
        Task<OrderHeaderModel?> GetOrderHeaderAsync(Expression<Func<OrderHeaderModel,bool>> where,bool AsNoTracker = false);
    }
}
