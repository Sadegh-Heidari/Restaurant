using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;

namespace Acc.Domain.Services
{
    public interface IAccRepositoryeBase<TEntity> where TEntity :BaseModel
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<int> GetCount();
    }
}
