namespace Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader
{
    public class AddSesionPaymentDto:IDisposable
    {
        public string OrderId { get; set; }
        public string SessionId { get; set; }
        public string PaymentIntentId { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
