using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class AddSesionPaymentDto:IDisposable
    {
        public string OrderId { get; set; }
        public string SessionId { get; set; }
        public string PaymentIntentId { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
