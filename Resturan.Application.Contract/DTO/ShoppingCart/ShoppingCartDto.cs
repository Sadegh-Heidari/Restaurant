using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.ShoppingCart
{
    public class ShoppingCartDto:IDisposable
    {
        public string? MenuItemId { get; set; }
        public string? MenuItemName { get; set; }
        public string? CategoryName { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
        public string? FoodTypeName { get; set; }
        public short count { get; set; } = 0;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
