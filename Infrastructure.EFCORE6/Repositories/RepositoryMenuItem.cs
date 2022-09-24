using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
