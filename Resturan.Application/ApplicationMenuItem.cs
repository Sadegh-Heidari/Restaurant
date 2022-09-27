using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.MenuItem;
using Resturan.Domain.MenuItem;
using Resturan.Domain.Services;

namespace Resturan.Application
{
    public class ApplicationMenuItem : IApplicationMenuItem
    {
        private IUnitOfWork _unitOfWork { get; }

        public ApplicationMenuItem(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddItem(CreatMenuItem dto)
        {
            MenuItemModel model = new(dto.Name!, dto.Descriptaion!, dto.Image!, dto.Price!, dto.FoodTypeName!, dto.CategoryName!);
            await _unitOfWork!.MenuItemRepository.AddAsync(model);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<MenuItemDTO>> GetAllItems()
        {
            var result = await _unitOfWork.MenuItemRepository.GetAllAsync(x=>new MenuItemDTO
            {
                CategoryName = x.Category.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                FoodTypeName = x.FoodType.Name,
                Id = x.Guid,
                Price = x.Price,
                Name = x.Name,
            },Include:"Category,FoodType");
            return result;
        }
    }
}
