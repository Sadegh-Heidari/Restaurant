using Restaurant.MainApp.Core.Domain.Category;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryCategory:RepositoryBase<CategoryModel>,IRepositoryCategory
    {
        public RepositoryCategory(ApplicationContext context) : base(context)
        {
        }
    }
}
