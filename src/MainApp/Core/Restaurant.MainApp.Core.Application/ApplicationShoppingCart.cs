using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Core.Domain.ShoppingCart;

namespace Restaurant.MainApp.Core.Application
{
    public class ApplicationShoppingCart : IApplicationShoppingCart
    {
        private IUnitOfWork _unitOfWork { get; }

        public ApplicationShoppingCart(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ShoppingCartDto>> GetAllCart(FindShopCartDto dto)
        {
            var result = await _unitOfWork.ShoppingCartRepository.GetAllAsync(x => new ShoppingCartDto
            {
                MenuItemId = x.MenuItemId,
                CategoryName = x.MenuItem.Category.Name,
                count = x.Count,
                FoodTypeName = x.MenuItem.FoodType.Name,
                Image = x.MenuItem.Image,
                MenuItemName = x.MenuItem.Name,
                Price = x.MenuItem.Price
            }, x => x.Email == dto.UserEmail);
            return result;
        }

        public async Task AddCart(CreatShoppingCartDto dto)
        {
            await _unitOfWork.ShoppingCartRepository.AddAsync(new ShoppingCartModel(dto.UserName!, dto.Email!, dto.Count,
                   dto.MenuItem!));
            _unitOfWork.Save();
        }

        public async Task<bool> IncrementCount(OperationShoppingDto dto)
        {
            var shop = await _unitOfWork.ShoppingCartRepository.GetByFilterAsync(x => x.Email == dto.UserEmail && x.MenuItemId == dto.MenuItemId);
            if (shop == null) return false;

            var result = (short)(shop.Count + dto.Count);
            shop.CangeCount(result);
            _unitOfWork.ShoppingCartRepository.Update(shop);
            _unitOfWork.Save();
            return true;
        }

        public async Task<bool> IsShoppingCartExist(OperationShoppingDto dto)
        {
            var IsShope =
                await _unitOfWork.ShoppingCartRepository.IsExist(x => x.Email == dto.UserEmail && x.MenuItemId == dto.MenuItemId);
            return IsShope;
        }

        public async Task<bool> DeIncrementCount(OperationShoppingDto dto)
        {
            var shop = await _unitOfWork.ShoppingCartRepository.GetByFilterAsync(x => x.Email == dto.UserEmail && x.MenuItemId == dto.MenuItemId);
            if (shop == null) return false;

            var result = (short)(shop.Count - dto.Count);
            if (result <= 0)
            {
                _unitOfWork.ShoppingCartRepository.DeleteCart(shop);
                _unitOfWork.Save();
                return true;
            }
            shop.CangeCount(result);
            _unitOfWork.ShoppingCartRepository.Update(shop);
            _unitOfWork.Save();
            return true;
        }

        public async Task<bool> DeleteCart(OperationShoppingDto dto)
        {
            var result = await 
                _unitOfWork.ShoppingCartRepository.GetByFilterAsync(x =>
                    x.Email == dto.UserEmail && x.MenuItemId == dto.MenuItemId,false);
            if (result == null) return false;
            _unitOfWork.ShoppingCartRepository.DeleteCart(result);
            _unitOfWork.Save();
            return true;
        }

        public async Task<IEnumerable<GetDetailsShoppingCart>> FindCart(FindShopCartDto dto)
        {
            var result = await _unitOfWork.ShoppingCartRepository.GetAllAsync(x => new GetDetailsShoppingCart
            {
                Count = x.Count,
                MenuItemId = x.MenuItemId,
                Name = x.MenuItem.Name,
                Price = x.MenuItem.Price
            }, x => x.Email == dto.UserEmail);
            return result;
        }

        public async Task DeleteAllCart(DeleteAllCart dto)
        {
            var result = await _unitOfWork.ShoppingCartRepository.GetAllCart(x=>x.Email==dto.UserEmail);
            _unitOfWork.ShoppingCartRepository.DeleteAllCart(result);
            _unitOfWork.Save();
        }

        public async Task<int> GetCountCart(FindShopCartDto dto)
        {
            var result = await _unitOfWork.ShoppingCartRepository.GetCount(x=>x.Email==dto.UserEmail);
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
