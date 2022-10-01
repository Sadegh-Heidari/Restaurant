using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.MenuItem;

namespace Resturan.Domain.Services
{
    public interface IRepositoryMenuItem:IRepositoryBase<MenuItem.MenuItemModel>
    {
        bool Delete(MenuItemModel model);
    }
}
