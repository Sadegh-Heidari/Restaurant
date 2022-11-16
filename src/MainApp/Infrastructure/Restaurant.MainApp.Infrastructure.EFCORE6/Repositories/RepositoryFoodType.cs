using Restaurant.MainApp.Core.Domain.FoodType;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryFoodType:RepositoryBase<FoodTypeModel>, IRepositoryFoodType
    {
        public RepositoryFoodType(ApplicationContext context) : base(context)
        {
        }
    }
}
