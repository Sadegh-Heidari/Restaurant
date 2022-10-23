using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.ShoppingCart
{
    public class OperationShoppingDto:IDisposable
    {
        public string? UserEmail { get; set; }
        public string? MenuItemId { get; set; }
        public short Count { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
