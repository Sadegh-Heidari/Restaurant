using Restaurant.MainApp.Infrastructure.EFCORE6.Context;
using Restaurant.MainApp.Core.Domain.Services;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        private ApplicationContext? _context { get;  }

        private IRepositoryFoodType? _foodTypeRepository;
        private IRepositoryCategory? _categoryRepository;
        private IRepositoryMenuItem? _menuItemRepository;
        private IShoppingCartRepository? _shoppingCartRepository;
        private IRepositoryOrderHeader? _orderHeader;
        private IRepositoryOrderDetail? _orderDetail;
        public IRepositoryCategory CategoryRepository => _categoryRepository ??= new RepositoryCategory(_context!);
        public IRepositoryFoodType FoodTypeRepository => _foodTypeRepository ??= new RepositoryFoodType(_context!);
        public IRepositoryMenuItem MenuItemRepository => _menuItemRepository ??= new RepositoryMenuItem(_context!);
        public IShoppingCartRepository ShoppingCartRepository =>
            _shoppingCartRepository ??= new ShoppingCartRepository(_context!);
        public IRepositoryOrderHeader OrderHeader => _orderHeader ??= new RepositoryOrderHeader(_context!);
        public IRepositoryOrderDetail OrderDetail=>_orderDetail??=new RepositoryOrderDetail(_context!);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            _context!.SaveChanges();
        }
        private bool isDisposed = false;

        private  void Dispose(bool disposing)
        {
            if(isDisposed) return;

            
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
            
            this.isDisposed = true;
        }

    }
}
