using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Services.Services
{
    public interface IOperationValue : IDisposable
    {
        public bool IsSucessed { get; set; }
        public string ResultMessage { get; set; }
        IOperationValue ShowResult(bool IsSuccessed, string Message);
    }
}
