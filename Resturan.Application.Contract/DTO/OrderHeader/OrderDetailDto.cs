using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class OrderDetailDto
    {
        public string? MenuItemId { get; set; }
        public string? Count { get; set; }
        public string? Price { get; set; }
    }
}
