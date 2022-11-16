namespace Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader
{
    public class GetOrderDetails:IDisposable
    {
        public string FoodName { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
