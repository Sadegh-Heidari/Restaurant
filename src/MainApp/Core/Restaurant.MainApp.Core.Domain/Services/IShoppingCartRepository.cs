using System.Linq.Expressions;
using Restaurant.MainApp.Core.Domain.ShoppingCart;

namespace Restaurant.MainApp.Core.Domain.Services
{
    public interface IShoppingCartRepository:IDisposable,IRepositoryBase<ShoppingCartModel>
    {
        Task<bool> IsExist(Expression<Func<ShoppingCartModel, bool>> where);
        void DeleteCart(ShoppingCartModel model);
        Task<IEnumerable<ShoppingCartModel>> GetAllCart(Expression<Func<ShoppingCartModel, bool>> where,bool AsNoTracking=true);
        void DeleteAllCart(IEnumerable<ShoppingCartModel> model);
    }
}
