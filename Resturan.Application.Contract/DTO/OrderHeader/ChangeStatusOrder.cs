using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class ChangeStatusOrder:IDisposable
    {
        public string OrderId { get; set; }
        public string Status { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
