using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO.ShoppingCart;

namespace Resturan.Application.Service.ApplicationServices
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
    }
}
