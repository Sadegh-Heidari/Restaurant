using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.ShoppingCart
{
    public class CreatShoppingCartDto:IDisposable
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public short Count { get; set; }
        public string? MenuItem { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
