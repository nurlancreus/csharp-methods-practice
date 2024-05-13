using BoltFood.Core.Models.BaseModel;
using BoltFood.CoreModels;
using BoltFood.Data.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private static List<T> _entities = new List<T>();
        public void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _entities.Add(entity);
        }

        public bool IfAny()
        {
            return _entities.Any();
        }

        public void Delete(int id)
        {
            T entity = GetById(id);

            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public List<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
   
            T foundEntity = _entities.FirstOrDefault(r => r.Id == id);

            if (foundEntity != null) return foundEntity;
            else throw new Exception($"{typeof(T)} not found");
        }

        public void Update(int id, T entity)
        {
            T updatedEntity = GetById(id);
            if (updatedEntity != null)
            {
                entity.UpdatedAt = DateTime.Now;
                //updatedEntity = entity;
                _entities[_entities.IndexOf(updatedEntity)] = entity;
            }

        }
    }
}
