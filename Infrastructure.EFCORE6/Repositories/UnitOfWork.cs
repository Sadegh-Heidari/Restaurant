using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EFCORE6.Context;
using Resturan.Domain.Services;

namespace Infrastructure.EFCORE6.Repositories
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
