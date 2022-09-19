using Resturan.Domain.Category;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryCategory:RepositoryBase<CategoryModel>,IRepositoryCategory
    {
        public RepositoryCategory(ApplicationContext context) : base(context)
        {
        }
    }
}
