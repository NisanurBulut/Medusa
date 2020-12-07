using IBlog.DataAccess.Context;
using IBlog.DataAccess.Interface;
using IBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Concrete
{
    public class GenericDal<tEntity> : IGenericDal<tEntity> where tEntity : class, ITable, new()
    {
        public async Task AddAsync(tEntity item)
        {
            using var context = new DatabaseContext();
            await context.AddAsync(item);
            await context.SaveChangesAsync();

        }

        public async Task<tEntity> FindByIdAsync(int id)
        {
            using var context = new DatabaseContext();
            return await context.FindAsync<tEntity>(id);
        }

        public async Task<List<tEntity>> GetAllAsync()
        {
            using var context = new DatabaseContext();
            return await context.Set<tEntity>().ToListAsync();
        }

        public async Task<List<tEntity>> 
            GetAllAsync<tKey>(Expression<Func<tEntity, bool>> filter, Expression<Func<tEntity,tKey>> keySelector)
        {
            using var context = new DatabaseContext();
            return await context.Set<tEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<List<tEntity>>
            GetAllAsync<tKey>(Expression<Func<tEntity, tKey>> keySelector)
        {
            using var context = new DatabaseContext();
            return await context.Set<tEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<tEntity>> GetAllAsync(Expression<Func<tEntity, bool>> filter)
        {
            using var context = new DatabaseContext();
            return await context.Set<tEntity>().Where(filter).ToListAsync();
        }
        public async Task<tEntity> GetAsync(Expression<Func<tEntity, bool>> filter)
        {
            using var context = new DatabaseContext();
            return await context.Set<tEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(tEntity item)
        {
            using var context = new DatabaseContext();
             context.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(tEntity item)
        {
            using var context = new DatabaseContext();
            context.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
