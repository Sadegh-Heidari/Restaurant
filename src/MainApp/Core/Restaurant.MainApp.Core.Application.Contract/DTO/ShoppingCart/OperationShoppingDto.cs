namespace Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart
{
    public class OperationShoppingDto:IDisposable
    {
        public string? UserEmail { get; set; }
        public string? MenuItemId { get; set; }
        public short Count { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
