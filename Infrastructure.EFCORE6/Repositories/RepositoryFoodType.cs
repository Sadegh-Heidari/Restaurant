using Resturan.Domain.FoodType;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryFoodType:RepositoryBase<FoodTypeModel>, IRepositoryFoodType
    {
        public RepositoryFoodType(ApplicationContext context) : base(context)
        {
        }
    }
}
