using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class GetOrderDetails:IDisposable
    {
        public string FoodName { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
