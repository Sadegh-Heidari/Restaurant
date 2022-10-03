using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<IEnumerable<Tout>> GetCustomer<Tout>(Expression<Func<MenuItemModel, Tout>> select, Expression<Func<MenuItemModel, bool>> where, Func<IQueryable<MenuItemModel>,IOrderedQueryable<Tout>> orderby, string? Include = null)
        {
            IQueryable<MenuItemModel> query = _context.Set<MenuItemModel>();
            query = query.Where(where);
            if (Include != null)
            {
                foreach (var item in Include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item).Where(x => x.IsDeleted == false);
                }
            }

            query.Select(select);
            var result = orderby(query);
            return result;
        }
    }
}
