
using Restaurant.UsersApp.Core.Application.Services.Services;

namespace Restaurant.UsersApp.Core.Application
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
