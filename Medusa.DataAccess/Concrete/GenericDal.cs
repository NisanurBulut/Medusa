using Medusa.DataAccess.Context;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medusa.DataAccess.Concrete
{
    public class GenericDal<tEntity> : IGenericDal<tEntity> where tEntity : class, ITable, new()
    {
        private readonly DatabaseContext _context;
        public GenericDal(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(tEntity item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();

        }

        public async Task<tEntity> FindByIdAsync(int id)
        {
            return await _context.FindAsync<tEntity>(id);
        }

        public async Task<List<tEntity>> GetAllAsync()
        {
            return await _context.Set<tEntity>().ToListAsync();
        }

        public async Task<List<tEntity>> 
            GetAllAsync<tKey>(Expression<Func<tEntity, bool>> filter, Expression<Func<tEntity,tKey>> keySelector)
        {
            return await _context.Set<tEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<List<tEntity>>
            GetAllAsync<tKey>(Expression<Func<tEntity, tKey>> keySelector)
        {
            return await _context.Set<tEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<tEntity>> GetAllAsync(Expression<Func<tEntity, bool>> filter)
        {
            return await _context.Set<tEntity>().Where(filter).ToListAsync();
        }
        public async Task<tEntity> GetAsync(Expression<Func<tEntity, bool>> filter)
        {
            return await _context.Set<tEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(tEntity item)
        {
             _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(tEntity item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
