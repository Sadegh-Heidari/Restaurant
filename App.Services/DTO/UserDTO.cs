using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Services.DTO
{
    public class UserDTO:IDisposable
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
