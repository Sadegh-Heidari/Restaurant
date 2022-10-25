using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
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
        public IRepositoryCategory CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new RepositoryCategory(_context!);
                    return _categoryRepository;
            }
        }

        public IRepositoryFoodType FoodTypeRepository
        {
            get
            {
                if(_foodTypeRepository == null) _foodTypeRepository = new RepositoryFoodType(_context!);
                return _foodTypeRepository;
            }
        }

        public IRepositoryMenuItem MenuItemRepository
        {
            get
            {
                if (_menuItemRepository == null)
                {
                    _menuItemRepository = new RepositoryMenuItem(_context!);
                }

                return _menuItemRepository;
            }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                if (_shoppingCartRepository == null)
                {
                    _shoppingCartRepository = new ShoppingCartRepository(_context!);
                }

                return _shoppingCartRepository;
            }
        }

        public IRepositoryOrderHeader OrderHeader
        {
            get
            {
                if (_orderHeader == null)
                {
                    _orderHeader = new RepositoryOrderHeader(_context!);
                }

                return _orderHeader;
            }
        }

        public IRepositoryOrderDetail OrderDetail
        {
            get
            {
                if (_orderDetail == null)
                {
                    _orderDetail = new RepositoryOrderDetail(_context!);
                }

                return _orderDetail;
            }
        }

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
