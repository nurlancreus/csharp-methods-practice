using E_Commerce.Core.Models.BaseModel;
using E_Commerce.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected static readonly List<T> _entities = [];
        public void Add(T entity) => _entities.Add(entity);

        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);
            if (entityToDelete != null) _entities.Remove(entityToDelete);
        }

        public List<T> GetAll() => _entities;

        public T? GetById(int id)
        {
            T? entity = _entities.FirstOrDefault(e => e.Id == id);

            if (entity == null) throw new Exception($"{typeof(T)} Not Found");
            else return entity;
        }

        public void Update(T entity)
        {
            T? entityToUpdate = GetById(entity.Id);
            if(entityToUpdate != null) entityToUpdate = entity;
        }
    }
}
