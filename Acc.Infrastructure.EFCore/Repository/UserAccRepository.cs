using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;
using Acc.Domain.Services;
using Acc.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Acc.Infrastructure.EFCore.Repository
{
    public class UserAccRepository:AccRepositoryBase<Users>,IUserAccRepository
    {
        public UserAccRepository(AccContext context) : base(context)
        {
        }

        public async Task<Users?> FindUserAsync(Expression<Func<Users, bool>> where, bool AsNoTracking = false)
        {
            IQueryable<Users> query = _context.Set<Users>();

            query = query.Where(where);
            if (AsNoTracking)
            {
                query = query.AsNoTracking();
            }
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> IsExistUserAsync(Expression<Func<Users, bool>> where)
        {
            IQueryable<Users> query = _context.Set<Users>();
            query = query.Where(where); var result = await query.AnyAsync();
           return result;
        }

        public async Task<T?> FindUserAsync<T>(Expression<Func<Users, bool>> where, Expression<Func<Users, T>> select, bool AsNoTracking = false)
        {
            IQueryable<Users> query = _context.Set<Users>();
            query = query.Where(where);
            if (AsNoTracking)
            {
               query= query.AsNoTracking();
            }
            var result = await query.Select(select).FirstOrDefaultAsync();
            return result;
        }

       
    }
}
