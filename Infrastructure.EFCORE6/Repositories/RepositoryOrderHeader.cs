using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
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
    }
}
