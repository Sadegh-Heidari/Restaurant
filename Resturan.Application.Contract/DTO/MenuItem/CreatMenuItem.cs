using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.MenuItem
{
    public class CreatMenuItem:MenuItemDTO
    {
        public override string? Name { get; set; }
        public override string? Descriptaion { get; set; }
        public override string? Image { get; set; }
        public override string? Price { get; set; }
        public override string? FoodTypeName { get; set; }
        public override string? CategoryName { get; set; }
    }
}
