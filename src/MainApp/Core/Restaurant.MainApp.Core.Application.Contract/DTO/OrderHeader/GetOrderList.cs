namespace Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader
{
    public class GetOrderList:IDisposable
    {
        public int OrderNumber { get; set; }
        public string Email { get; set; }
        public string  PhoneNumber { get; set; }
        public string OrderTotal { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string PickupTime { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
