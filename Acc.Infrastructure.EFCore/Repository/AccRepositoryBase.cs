using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;
using Acc.Domain.Services;
using Acc.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Acc.Infrastructure.EFCore.Repository
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
    }
}
