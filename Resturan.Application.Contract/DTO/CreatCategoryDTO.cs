using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO
{
    public class CreatCategoryDTO:IDisposable
    {
        public string Name { get; set; }
        public short DisplayOrder { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
