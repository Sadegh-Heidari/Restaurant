using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Restaurant.UsersApp.Core.Domain.Models;
using Restaurant.UsersApp.Core.Domain.Services;
using Restaurant.UsersApp.Infrastructure.EFCore.Context;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Repository
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

        public async Task<IEnumerable<T>> GetUsers<T>(Expression<Func<Users, T>> select, int page, int pagesize, Expression<Func<Users, bool>> where)
        {
            IQueryable<Users> query = _context.Set<Users>();
            query = query.Where(where);
            query= query.ToPaged( pagesize,page);
            var result = await query.Select(select).ToListAsync();
            return result;
        }

      
    }
}
