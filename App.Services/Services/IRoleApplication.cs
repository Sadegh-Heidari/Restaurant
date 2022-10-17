using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Services.DTO;

namespace Acc.Services.Services
{
    public interface IRoleApplication : IDisposable
    {
        Task<IOperationValue> CreatRole(Role role);
    }
}
