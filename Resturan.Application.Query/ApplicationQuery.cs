using Resturan.Application.Query.DTO;
using Resturan.Domain.MenuItem;
using Resturan.Domain.Services;

namespace Resturan.Application.Query
{
    public class ApplicationQuery
    {
        private IUnitOfWork _unitOfWork { get; }
        public ApplicationQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> s()
        {
            var result = await _unitOfWork.MenuItemRepository.GetCustomer(x => new CustomerDto
                {
                    CategoryName = x.Category.Name,
                    Description = x.Descriptaion,
                    FoodTypeName = x.FoodType.Name,
                    Image = x.Image,
                    Name = x.Name,
                    Price = x.Price
                }, x => x.Category.IsDeleted != false && x.FoodType.IsDeleted != false && x.IsDeleted != false,
                x => x.OrderBy(c => c.Category.DisplayOrder), "Category,FoodType");
        }
        
    }
}