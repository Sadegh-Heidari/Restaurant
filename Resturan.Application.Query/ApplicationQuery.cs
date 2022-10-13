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
                    Price = x.Price,
                    id = x.Guid
                }, 
                c => c.OrderBy(x => x.Category.DisplayOrder), x => x.IsDeleted == false && x.Category.IsDeleted == false && x.FoodType.IsDeleted == false, "Category,FoodType");
            _unitOfWork.Dispose();
            return result;
        }

        public async Task<CustomerDto?> GetCustomerById(string id)
        {
            var result = await _unitOfWork.MenuItemRepository.GetByIdAsync(x => new CustomerDto
            {
                id = x.Guid,
                Price = x.Price,
                Image = x.Image,
                CategoryName = x.Category.Name,
                FoodTypeName = x.FoodType.Name,
                Description = x.Descriptaion,
                Name = x.Name
            }, x => x.Guid == id, true, "Category,FoodType");
            _unitOfWork.Dispose();
            return result;
        }
    }
}