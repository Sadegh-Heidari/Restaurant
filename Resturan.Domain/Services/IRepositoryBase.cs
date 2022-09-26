using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Base;

namespace Resturan.Domain.Services
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseModel
    { 
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TOut>> GetAllAsync<TOut>( Expression<Func<TEntity, TOut>> Select,Expression<Func<TEntity,bool>>? Where=null);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> Where, bool AsNoTracking = true);
        Task<TOut?> GetByIdAsync<TOut>(Expression<Func<TEntity, TOut>> Select, Expression<Func<TEntity, bool>> Where,
            bool AsNoTracking = true);



    }
}
