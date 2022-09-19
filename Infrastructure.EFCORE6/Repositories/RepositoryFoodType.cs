using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EFCORE6.Context;
using Resturan.Domain.FoodType;
using Resturan.Domain.Services;

namespace Infrastructure.EFCORE6.Repositories
{
    public class RepositoryFoodType:RepositoryBase<FoodTypeModel>, IRepositoryFoodType
    {
        public RepositoryFoodType(ApplicationContext context) : base(context)
        {
        }
    }
}
