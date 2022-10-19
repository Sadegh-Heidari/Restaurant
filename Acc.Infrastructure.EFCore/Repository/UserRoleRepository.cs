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
    public class UserRoleRepository:IAccUserRoleRepository
    {
        private AccContext _context { get; }

        public UserRoleRepository(AccContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExistUserRoleAsync(UserRole userRole)
        {
            IQueryable<UserRole> query = _context.Set<UserRole>();
           query = query.Where(x => x.RoleId == userRole.RoleId&&x.UserId==userRole.UserId);
           var result = await query.AnyAsync();
           return result;
        }

        public async Task<bool> AddUserRoleAsync(UserRole userRole)
        {
            await _context.UserRoleDb.AddAsync(userRole);
            return true;
        }
        public async Task<IEnumerable<T>> GetUserRole<T>(Expression<Func<UserRole, T>> select, Expression<Func<UserRole, bool>> where)
        {
            IQueryable<UserRole> query = _context.Set<UserRole>();
            query = query.Where(where).AsNoTracking();
            var result = await query.Select(select).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<UserRole>> GetUserRole(Expression<Func<UserRole, bool>> where)
        {
            IQueryable<UserRole> query = _context.Set<UserRole>();
            query = query.Where(where);
            return await query.ToListAsync();
        }

        public bool DeleteUserRole(IEnumerable<UserRole> userRoles)
        {
            _context.Set<UserRole>().RemoveRange(userRoles);
            return true;
        }
    }
}
