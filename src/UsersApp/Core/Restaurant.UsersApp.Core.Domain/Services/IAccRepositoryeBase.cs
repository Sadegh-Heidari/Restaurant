using Restaurant.UsersApp.Core.Domain.Models;

namespace Restaurant.UsersApp.Core.Domain.Services
{
    public interface IAccRepositoryeBase<TEntity> where TEntity :BaseModel
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<int> GetCount();
        bool DeleteEntity(TEntity entity);
    }
}
