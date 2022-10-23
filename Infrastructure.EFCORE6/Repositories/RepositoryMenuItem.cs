using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resturan.Domain.MenuItem;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
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
