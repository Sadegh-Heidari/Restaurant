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
    public class RoleAccRepository:AccRepositoryBase<Role>,IRoleAccRepository
    {
        public RoleAccRepository(AccContext context) : base(context)
        {
        }

        public async Task<Role?> FindRoleAsync(Expression<Func<Role, bool>> where)
        {
            IQueryable<Role> query = _context.Set<Role>();
            query= query.Where(where);
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
    }
}
