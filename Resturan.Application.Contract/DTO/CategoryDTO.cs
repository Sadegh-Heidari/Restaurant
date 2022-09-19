using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO
{
    public class CategoryDTO:IDisposable
    {
        public string?  GUID { get; set; }
        public string?  Name { get; set; }
        public string?  CreationDate { get; set; }
        public short  DisplayOrder { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
