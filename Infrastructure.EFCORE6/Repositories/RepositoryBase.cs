using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Base;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        private ApplicationContext _context { get; }

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TOut>> GetAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>>? Where = null)
        {
            return Select != null && Where != null
                ? await _context.Set<TEntity>().AsNoTracking().Where(Where).Select(Select).ToListAsync()
                : await _context.Set<TEntity>().AsNoTracking().Select(Select!).ToListAsync();

        }

        public virtual async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> Where)
        {
            var result = await _context.Set<TEntity>().Where(Where).FirstOrDefaultAsync();
            return result;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
              await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual  void Update(TEntity entity)
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
                 _context.Set<TEntity>().Update(entity);

        }

    }

}
