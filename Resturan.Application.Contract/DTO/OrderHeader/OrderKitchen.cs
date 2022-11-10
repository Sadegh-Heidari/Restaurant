using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class OrderKitchen:IDisposable
    {
      public GetOrderList OrderList { get; set; }
        public IEnumerable<GetOrderDetails> OrderDetails { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
