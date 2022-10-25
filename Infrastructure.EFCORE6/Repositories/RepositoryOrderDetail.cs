using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Order;
using Resturan.Domain.OrderDetail;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryOrderDetail:RepositoryBase<OrderDetailModel>,IRepositoryOrderDetail
    {
        public RepositoryOrderDetail(ApplicationContext context) : base(context)
        {
        }
    }
}
