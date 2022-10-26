using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.ShoppingCart
{
	public class GetDetailsShoppingCart:IDisposable
	{
        public string? MenuItemId { get; set; }
        public short Count { get; set; }
        public string? Price { get; set; }
        public string? Name { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
