using IBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IBlog.Business
{
    public interface IGenericService<tEntity> where tEntity : class, ITable, new()
    {
        Task<List<tEntity>> GetAllAsync();
        Task<List<tEntity>> GetAllAsync(Expression<Func<tEntity, bool>> filter);
        Task<List<tEntity>> GetAllAsync<tKey>(Expression<Func<tEntity, tKey>> keySelector);
        Task<List<tEntity>> GetAllAsync<tKey>(Expression<Func<tEntity, bool>> filter, Expression<Func<tEntity, tKey>> keySelector);
        Task<tEntity> GetAsync(Expression<Func<tEntity, bool>> filter);
        Task AddAsync(tEntity item);

        Task UpdateAsync(tEntity item);
        Task RemoveAsync(tEntity item);
    }
}
