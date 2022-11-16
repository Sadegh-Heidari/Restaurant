namespace Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart
{
    public class FindShopCartDto:IDisposable
    {
        public string UserEmail { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
