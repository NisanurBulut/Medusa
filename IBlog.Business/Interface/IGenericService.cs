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
        
        Task<tEntity> FindByIdAsync(int);
        Task AddAsync(tEntity item);

        Task UpdateAsync(tEntity item);
        Task RemoveAsync(tEntity item);
    }
}
