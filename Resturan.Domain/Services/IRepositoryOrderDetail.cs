using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Order;
using Resturan.Domain.OrderDetail;

namespace Resturan.Domain.Services
{
    public interface IRepositoryOrderDetail:IRepositoryBase<OrderDetailModel>
    {
    }
}
