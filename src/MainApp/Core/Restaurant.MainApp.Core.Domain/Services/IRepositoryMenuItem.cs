using System.Linq.Expressions;
using Restaurant.MainApp.Core.Domain.MenuItem;

namespace Restaurant.MainApp.Core.Domain.Services
{
    public interface IRepositoryMenuItem:IRepositoryBase<MenuItem.MenuItemModel>
    {
        bool Delete(MenuItemModel model);

        Task<IEnumerable<Tout>> GetMenuItemAllAsync<Tout>(Expression<Func<MenuItemModel, Tout>> select,
            Func<IQueryable<MenuItemModel>, IOrderedQueryable<MenuItemModel>> orderby,
            Expression<Func<MenuItemModel, bool>>? where = null, string? Include = null);





    }
}
