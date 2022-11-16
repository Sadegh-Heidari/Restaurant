namespace Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart
{
	public class GetDetailsShoppingCart:IDisposable
	{
        public string? MenuItemId { get; set; }
        public short Count { get; set; }
        public string? Price { get; set; }
        public string? Name { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
