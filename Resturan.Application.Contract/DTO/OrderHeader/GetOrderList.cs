using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class GetOrderList:IDisposable
    {
        public int OrderNumber { get; set; }
        public string Email { get; set; }
        public string  PhoneNumber { get; set; }
        public string OrderTotal { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string PickupTime { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
