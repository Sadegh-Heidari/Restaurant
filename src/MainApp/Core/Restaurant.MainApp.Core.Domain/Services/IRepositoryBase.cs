using System.Linq.Expressions;
using Restaurant.MainApp.Core.Domain.Base;

namespace Restaurant.MainApp.Core.Domain.Services
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseModel
    { 
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>>? Where = null);
        Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>>? Where = null, string? Include=null);
        Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, int page, int pagesize, Expression<Func<TEntity, bool>>? Where = null, string? Include = null );
        Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity, TOut>> Select, int page , int pagesize );
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> Where, bool AsNoTracking = true);
        Task<TOut?> GetByFilterAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>> Where,
            bool AsNoTracking = true,string? include=null);

        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<TEntity,bool>>where);
    }
}
