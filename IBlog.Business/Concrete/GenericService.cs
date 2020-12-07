using IBlog.DataAccess.Interface;
using IBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IBlog.Business.Concrete
{
    public class GenericService<tEntity> : IGenericService<tEntity> where tEntity : class, ITable, new()
    {
        private IGenericDal<tEntity> _genericDal;
        public GenericService(IGenericDal<tEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task AddAsync(tEntity item)
        {
            await _genericDal.AddAsync(item);
        }

        public async Task<List<tEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<List<tEntity>> GetAllAsync(Expression<Func<tEntity, bool>> filter)
        {
            return await _genericDal.GetAllAsync(filter);
        }

        public async Task<List<tEntity>> GetAllAsync<tKey>(Expression<Func<tEntity, tKey>> keySelector)
        {
            return await _genericDal.GetAllAsync(keySelector);

        }

        public async Task<List<tEntity>> GetAllAsync<tKey>(Expression<Func<tEntity, bool>> filter, Expression<Func<tEntity, tKey>> keySelector)
        {
            return await _genericDal.GetAllAsync(filter, keySelector);
        }

        public async Task<tEntity> GetAsync(Expression<Func<tEntity, bool>> filter)
        {
            return await _genericDal.GetAsync(filter);
        }

        public async Task RemoveAsync(tEntity item)
        {
            await _genericDal.RemoveAsync(item);

        }
        public async Task UpdateAsync(tEntity item)
        {
            await _genericDal.UpdateAsync(item);
        }
    }
}
