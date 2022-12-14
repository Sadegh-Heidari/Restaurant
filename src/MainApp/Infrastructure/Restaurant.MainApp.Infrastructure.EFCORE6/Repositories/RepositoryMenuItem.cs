using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Restaurant.MainApp.Core.Domain.MenuItem;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryMenuItem:RepositoryBase<MenuItemModel> , IRepositoryMenuItem
    {
        public RepositoryMenuItem(ApplicationContext context) : base(context)
        {
        }

        public bool Delete(MenuItemModel model)
        {
            if (_context.Entry(model).State != EntityState.Deleted)
            {
                _context.MenuItem.Remove(model);
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Tout>> GetMenuItemAllAsync<Tout>(Expression<Func<MenuItemModel, Tout>> select, Func<IQueryable<MenuItemModel>, IOrderedQueryable<MenuItemModel>> orderby, Expression<Func<MenuItemModel, bool>>? where=null, string? Include = null)
        {
            IQueryable<MenuItemModel> query = _context.Set<MenuItemModel>();
            if(where != null)
            query = query.Where(where);
            if (Include != null)
            {
                foreach (var item in Include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item).Where(x => x.IsDeleted == false);
                }
            }

            query = orderby(query);
            var result =  query.AsNoTracking().Select(select);
           return await result.ToListAsync();
        }
    }
}
