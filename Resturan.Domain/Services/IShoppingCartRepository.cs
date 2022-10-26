using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.ShoppingCart;

namespace Resturan.Domain.Services
{
    public interface IShoppingCartRepository:IDisposable,IRepositoryBase<ShoppingCartModel>
    {
        Task<bool> IsExist(Expression<Func<ShoppingCartModel, bool>> where);
        void DeleteCart(ShoppingCartModel model);
        Task<IEnumerable<ShoppingCartModel>> GetAllCart(Expression<Func<ShoppingCartModel, bool>> where,bool AsNoTracking=true);
        void DeleteAllCart(IEnumerable<ShoppingCartModel> model);
    }
}
