using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Restaurant.UsersApp.Core.Domain.Models;
using Restaurant.UsersApp.Core.Domain.Services;
using Restaurant.UsersApp.Infrastructure.EFCore.Context;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Repository
{
    public class RoleAccRepository:AccRepositoryBase<Role>,IRoleAccRepository
    {
        public RoleAccRepository(AccContext context) : base(context)
        {
        }

        public async Task<Role?> FindRoleAsync(Expression<Func<Role, bool>> where, bool AsNoTracking = false)
        {
            IQueryable<Role> query = _context.Set<Role>();
            query= query.Where(where);
            if (AsNoTracking)
            {
                query = query.AsNoTracking();
            }
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> IsExistRole(Expression<Func<Role, bool>> where)
        {
            IQueryable<Role> query = _context.Set<Role>();
           query= query.Where(where);
           var result = await query.AnyAsync();
           return result;
        }

        public async Task<IEnumerable<T?>> GetAllRole<T>(Expression<Func<Role, T>> select, bool AsNoTracking = false)
        {
            IQueryable<Role> query = _context.Set<Role>();
            if (AsNoTracking) query = query.AsNoTracking();
            var result = await query.Select(select).ToListAsync();
            return result;
        }
    }
}
