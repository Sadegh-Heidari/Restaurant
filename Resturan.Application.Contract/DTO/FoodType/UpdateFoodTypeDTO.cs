using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.FoodType
{
    public class UpdateFoodTypeDTO:FoodTypeDTO
    {
        public override string? Id { get; set; }
        public override string? Name { get; set; }
    }
}
