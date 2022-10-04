using Resturan.Application.Query.DTO;
using Resturan.Domain.MenuItem;
using Resturan.Domain.Services;

namespace Resturan.Application.Query
{
    public class ApplicationQuery:IApplicationQuery
    {
        private IUnitOfWork _unitOfWork { get; }
        public ApplicationQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<CustomerDto>> GetCustomerQuery()
        {
            var result = await _unitOfWork.MenuItemRepository.GetCustomer(x => new CustomerDto
                {
                    CategoryName = x.Category.Name,
                    Description = x.Descriptaion,
                    FoodTypeName = x.FoodType.Name,
                    Image = x.Image,
                    Name = x.Name,
                    Price = x.Price
                }, 
                c => c.OrderBy(x => x.Category.DisplayOrder), x => x.IsDeleted == false && x.Category.IsDeleted == false && x.FoodType.IsDeleted == false, "Category,FoodType");
            return result;
        }
    }
}