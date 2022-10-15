using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Services.Services;

namespace Acc.Application
{
    public class OperationValue:IOperationValue
    {
        public bool IsSucessed { get; set; }
        public string ResultMessage { get; set; }
        public IOperationValue ShowResult(bool IsSuccessed, string Message)
        {
            this.IsSucessed = IsSuccessed;
            this.ResultMessage = Message;
            return this;
        }
    }
}
