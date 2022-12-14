using System.Globalization;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO;
using Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem;
using Restaurant.MainApp.Core.Domain.MenuItem;
using Restaurant.MainApp.Core.Domain.Services;

namespace Restaurant.MainApp.Core.Application
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

        public async Task<Pageniation> GetAllItems(Pageniation pg)
        {
            pg.MenuItem = await _unitOfWork.MenuItemRepository.GetAllAsync(x=>new MenuItemDTO
            {
                CategoryName = x.Category.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                FoodTypeName = x.FoodType.Name,
                Id = x.Guid,
                Price = x.Price,
                Name = x.Name,
            },Include:"Category,FoodType",page:pg.PageSize,pagesize:pg.PageNumber);
            pg.Count = await _unitOfWork.MenuItemRepository.GetCount();
            return pg;
        }

        public async Task<bool> DeleteItem(DeleteMenuItemDTO dto)
        {
            var item = await _unitOfWork.MenuItemRepository.GetByFilterAsync(x => x.Guid == dto.GUId, false);
            if (item == null) return false;
           var result = _unitOfWork.MenuItemRepository.Delete(item);
            _unitOfWork.Save();
           return result;
        }

        public async Task<MenuItemDTO?> getItem(string id)
        {
            var result = await _unitOfWork.MenuItemRepository.GetByFilterAsync(x => new MenuItemDTO
            {
                Id = x.Guid,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                Descriptaion = x.Descriptaion,
            }, x => x.Guid == id);
            return result;
        }

        public async Task<bool> UpdateItem(UpdateMenuItemDTO dto)
        {
            var model = await _unitOfWork.MenuItemRepository.GetByFilterAsync(x => x.Guid == dto.Id, false);
            if (model == null) return false;
            model.Update(dto.Name!,dto.Descriptaion!,dto.Image!,dto.Price!,dto.FoodTypeName!,dto.CategoryName!);
             _unitOfWork.MenuItemRepository.Update(model);
             _unitOfWork.Save();
             return true;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
