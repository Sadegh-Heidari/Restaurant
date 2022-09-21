using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.FoodType
{
    public class CreatFoodTypeDTO:IDisposable
    {
        public  string? Name { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
