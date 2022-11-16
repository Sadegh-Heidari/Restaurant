namespace Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader
{
    public class OrderKitchen:IDisposable
    {
      public GetOrderList OrderList { get; set; }
        public IEnumerable<GetOrderDetails> OrderDetails { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
