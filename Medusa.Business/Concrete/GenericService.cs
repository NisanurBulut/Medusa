using Medusa.DataAccess.Interface;
using Medusa.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
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

        public async Task<tEntity> FindByIdAsync(int id)
        {
           return  await _genericDal.FindByIdAsync(id);
        }

        public async Task<List<tEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
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
