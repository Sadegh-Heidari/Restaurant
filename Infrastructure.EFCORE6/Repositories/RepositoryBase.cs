using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Base;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;
using Resturan.Infrastructure.EFCORE6.Pagination;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Resturan.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        protected ApplicationContext _context { get; }
        private DbSet<TEntity> dbset { get; }
        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            dbset = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>>? Where = null)
        {
            IQueryable<TEntity> query = dbset;
            if (Where != null)
            {
                query = query.AsNoTracking().Where(Where);
            }
            var q = query.AsNoTracking().Select(Select).ToQueryString();

            var result = await query.AsNoTracking().Select(Select).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>>? Where = null, string? Include = null)
        {
            IQueryable<TEntity> query = dbset;
            if (Where != null)
            {
                query = query.AsNoTracking().Where(Where);
            }

            if (Include != null)
            {
                foreach (var item in Include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            var result = await query.AsNoTracking().Select(Select).ToListAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, int page, int pagesize, Expression<Func<TEntity, bool>>? Where = null, string? Include = null)
        {
            IQueryable<TEntity> query = dbset;
            if (Where != null)
            {
                query = query.AsNoTracking().Where(Where);
            }

            if (Include != null)
            {
                foreach (var item in Include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            var skip = (page - 1) * pagesize;
            var result = query.AsNoTracking().Select(Select).Skip(skip).Take(pagesize);
            return await result.ToListAsync();
           

        }

        public async Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, int page, int pagesize)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            var result = query.AsNoTracking().Select(Select).ToPaged(page, pagesize);
            return await result.ToListAsync();

        }

        public virtual async Task<TEntity?> GetByFilter(Expression<Func<TEntity, bool>> Where, bool AsNoTracking = true)
        {
            IQueryable<TEntity> query = dbset;
            if (AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            var result = await query.Where(Where).FirstOrDefaultAsync();

            return result;

            
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
                _context.Set<TEntity>().Update(entity);

        }

        public virtual async Task<TOut?> GetByFilter<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>> Where, bool AsNoTracking = true, string? include = null)
        {

            IQueryable<TEntity> query = dbset;
            if (AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                foreach (var item in include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (Where != null)
            {
                query = query.Where(Where);
            }
            var result = await query.Select(Select).FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> GetCount()
        {

            return await dbset.CountAsync();
        }

    }

}

