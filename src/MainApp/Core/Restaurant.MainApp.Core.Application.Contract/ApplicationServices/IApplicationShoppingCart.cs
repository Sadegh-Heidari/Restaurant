using Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart;

namespace Restaurant.MainApp.Core.Application.Contract.ApplicationServices
{
    public interface IApplicationShoppingCart:IDisposable
    {
        Task<IEnumerable<ShoppingCartDto>> GetAllCart(FindShopCartDto dto);
        Task AddCart(CreatShoppingCartDto dto);
        Task<bool> IncrementCount(OperationShoppingDto dto);
        Task<bool> IsShoppingCartExist(OperationShoppingDto dto);
        Task<bool> DeIncrementCount(OperationShoppingDto dto);
        Task<bool> DeleteCart(OperationShoppingDto dto);
        Task<IEnumerable<GetDetailsShoppingCart>> FindCart(FindShopCartDto dto);
        Task DeleteAllCart(DeleteAllCart dto);
        Task<int> GetCountCart(FindShopCartDto dto);
    }
}
