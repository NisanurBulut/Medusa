using IBlog.DataAccess.Context;
using IBlog.DataAccess.Interface;
using IBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<tEntity>> GetAllAsync()
        {
            using var context = new DatabaseContext();
            return await context.Set<tEntity>().ToListAsync();
        }

        public Task<List<tEntity>> GetAllAsync(Expression<Func<tEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<tEntity> GetAsync(Expression<Func<tEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(tEntity item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(tEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
