using College.Core.Models.BaseModels;
using College.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Data.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly static List<T> _entities = [];
        public async Task AddAsync(T entity)
        {
            _entities.Add(entity);
            await Task.CompletedTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T? foundEntity = await GetByIdAsync(id);
            if (foundEntity != null)
            {
                _entities.Remove(foundEntity);
                return true;
            }
            else return false;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Task.FromResult(_entities);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            T? foundEntitiy = _entities.FirstOrDefault(e => e.Id == id);

            return await Task.FromResult(foundEntitiy);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            T? foundEntity = await GetByIdAsync(entity.Id);

            if (foundEntity != null)
            {
                //foundEntity = entity;
                _entities[_entities.IndexOf(foundEntity)] = entity;
                return true;
            }
            else return false;
        }
    }
}
