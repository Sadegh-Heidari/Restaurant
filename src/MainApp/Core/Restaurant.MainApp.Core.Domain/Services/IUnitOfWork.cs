namespace Restaurant.MainApp.Core.Domain.Services
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepositoryCategory CategoryRepository { get; }
        public IRepositoryFoodType FoodTypeRepository { get; }
        public IRepositoryMenuItem MenuItemRepository { get; }
        public IShoppingCartRepository ShoppingCartRepository { get; }
        public IRepositoryOrderHeader OrderHeader { get; }
        public IRepositoryOrderDetail OrderDetail { get; }
        void Save();
    }
}
