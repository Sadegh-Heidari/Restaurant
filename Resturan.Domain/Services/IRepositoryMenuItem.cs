using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.MenuItem;

namespace Resturan.Domain.Services
{
    public interface IRepositoryMenuItem:IRepositoryBase<MenuItem.MenuItemModel>
    {
        bool Delete(MenuItemModel model);

        Task<IEnumerable<Tout>> GetCustomer<Tout>(Expression<Func<MenuItemModel, Tout>> select,
            Expression<Func<MenuItemModel, bool>> where,
            Func<IQueryable<MenuItemModel>, IOrderedQueryable<Tout>> orderby, string? Include = null);




    }
}
