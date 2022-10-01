using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
