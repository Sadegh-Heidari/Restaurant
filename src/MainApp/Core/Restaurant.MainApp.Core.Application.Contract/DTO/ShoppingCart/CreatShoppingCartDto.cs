namespace Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart
{
    public class CreatShoppingCartDto:IDisposable
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public short Count { get; set; }
        public string? MenuItem { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
