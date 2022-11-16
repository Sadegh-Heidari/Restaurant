using Microsoft.EntityFrameworkCore;
using Restaurant.UsersApp.Core.Domain.Models;
using Restaurant.UsersApp.Core.Domain.Services;
using Restaurant.UsersApp.Infrastructure.EFCore.Context;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Repository
{
    public class AccRepositoryBase<TEntity>:IAccRepositoryeBase<TEntity> where TEntity:BaseModel
    {
        protected AccContext _context { get; }

        public AccRepositoryBase(AccContext context)
        {
            _context = context;
            
        }

        public async Task AddAsync(TEntity entity)
        {
             await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
            {
                _context.Set<TEntity>().Update(entity: entity);
            }
        }

        public async Task<int> GetCount()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            var result = await query.CountAsync();
            return result;
        }

        public bool DeleteEntity(TEntity entity)
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
            }

            return false;
        }
    }
}
