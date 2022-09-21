using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.FoodType
{
    public class FoodTypeDTO:IDisposable
    {
        public virtual string?  Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? CreationDate { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
