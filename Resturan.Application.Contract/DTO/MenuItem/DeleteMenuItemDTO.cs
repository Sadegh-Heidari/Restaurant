using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.MenuItem
{
    public class DeleteMenuItemDTO:IDisposable
    {
        public string? GUId { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
