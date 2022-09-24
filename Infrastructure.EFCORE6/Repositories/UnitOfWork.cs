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

        private ApplicationContext _context { get; }

        private IRepositoryFoodType? _foodTypeRepository;
        private IRepositoryCategory? _categoryRepository;
        private IRepositoryMenuItem? _menuItemRepository;
        public IRepositoryCategory CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new RepositoryCategory(_context);
                    return _categoryRepository;
            }
        }

        public IRepositoryFoodType FoodTypeRepository
        {
            get
            {
                if(_foodTypeRepository == null) _foodTypeRepository = new RepositoryFoodType(_context);
                return _foodTypeRepository;
            }
        }

        public IRepositoryMenuItem MenuItemRepository
        {
            get
            {
                if (_menuItemRepository == null)
                {
                    _menuItemRepository = new RepositoryMenuItem(_context);
                }

                return _menuItemRepository;
            }
        }

        public void Dispose()
        {
            if(_context != null) _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
