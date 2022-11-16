namespace Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader
{
    public class ChangeStatusOrder:IDisposable
    {
        public string OrderId { get; set; }
        public string Status { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
