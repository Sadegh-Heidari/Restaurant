namespace Restaurant.UsersApp.Core.Application.Services.Services
{
    public interface IOperationValue : IDisposable
    {
        public bool IsSucessed { get; set; }
        public string ResultMessage { get; set; }
        IOperationValue ShowResult(bool IsSuccessed, string Message);
    }
}
