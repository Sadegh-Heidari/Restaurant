using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EFCORE6.Context;
using Resturan.Domain.Category;
using Resturan.Domain.Services;

namespace Infrastructure.EFCORE6.Repositories
{
    public class RepositoryCategory:RepositoryBase<CategoryModel>,IRepositoryCategory
    {
        public RepositoryCategory(ApplicationContext context) : base(context)
        {
        }
    }
}
