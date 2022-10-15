using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Services.DTO
{
    public class Role:IDisposable
    {
        public string? Name { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
