﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Base;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;

namespace Resturan.Infrastructure.EFCORE6.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        private ApplicationContext _context { get; }
        private DbSet<TEntity> dbset { get; }
        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            dbset = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TOut>> GetAllAsync<TOut>(Expression<Func<TEntity,TOut>> Select, Expression<Func<TEntity, bool>>? Where = null,string? Include=null)
        {
            IQueryable<TEntity> query = dbset;
            if (Where != null)
            {
               query = query.AsNoTracking().Where(Where);
            }

            if (Include != null)
            {
                foreach (var item in Include.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            var result= await  query.AsNoTracking().Select(Select).ToListAsync();
            return result;
            //var result = Select != null && Where != null
            //    ? await _context.Set<TEntity>().AsNoTracking().Where(Where).Select(Select).ToListAsync()
            //    : await _context.Set<TEntity>().AsNoTracking().Select(Select!).ToListAsync();

        }

        public virtual async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> Where, bool AsNoTracking = true)
        {
            IQueryable<TEntity> query = dbset;
            if (AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            var result = await query.Where(Where).FirstOrDefaultAsync();

            return result;

            //var result = AsNoTracking == true ? await _context.Set<TEntity>().AsNoTracking().Where(Where).FirstOrDefaultAsync() :
            //    await _context.Set<TEntity>().Where(Where).FirstOrDefaultAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
              await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual  void Update(TEntity entity)
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
                 _context.Set<TEntity>().Update(entity);

        }

        public virtual async Task<TOut?> GetByIdAsync<TOut>(Expression<Func<TEntity, TOut>> Select,Expression<Func<TEntity, bool>> Where ,bool AsNoTracking= true)
        {

            IQueryable<TEntity> query = dbset;
            if (AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (Where != null)
            {
                query = query.Where(Where);
            }

                var result  = await query.Select(Select).FirstOrDefaultAsync();
                return result;
            //var result =   AsNoTracking == true
            //    ? await _context.Set<TEntity>().AsNoTracking().Where(Where).Select(Select).FirstOrDefaultAsync()
            //    : await _context.Set<TEntity>().Where(Where).Select(Select).FirstOrDefaultAsync();
            //return result!;
        }
    }
   
    }
    
