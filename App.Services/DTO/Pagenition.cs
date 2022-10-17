using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Services.DTO
{
    public class Pagenition:IDisposable
    {
        public IEnumerable<UserDTO> users { get; set; }
        public long Count { get; set; }
        public int  PageSize { get; set; }
        public int PageNumber { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
