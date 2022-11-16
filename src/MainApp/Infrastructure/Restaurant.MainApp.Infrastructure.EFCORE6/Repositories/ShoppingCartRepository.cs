using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Core.Domain.ShoppingCart;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class ShoppingCartRepository:RepositoryBase<ShoppingCartModel>,IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationContext context) : base(context)
        {
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<bool> IsExist(Expression<Func<ShoppingCartModel, bool>> where)
        {
            IQueryable<ShoppingCartModel> query = _context.Set<ShoppingCartModel>();
            query = query.AsNoTracking();
            query = query.Where(where);
            var result = await query.AnyAsync();
            return result;
        }

        public void DeleteCart(ShoppingCartModel model)
        {
            _context.Set<ShoppingCartModel>().Remove(model);
        }

        public async Task<IEnumerable<ShoppingCartModel>> GetAllCart(Expression<Func<ShoppingCartModel, bool>> where, bool AsNoTracking = true)
        {
            IQueryable<ShoppingCartModel> query = _context.Set<ShoppingCartModel>();
            if (AsNoTracking) query = query.AsNoTracking();
            query=query.Where(where);
            var result =await query.ToListAsync();
            return result;
        }

        public void DeleteAllCart(IEnumerable<ShoppingCartModel> model)
        {
            _context.Set<ShoppingCartModel>().RemoveRange(model);
        }
    }
}
