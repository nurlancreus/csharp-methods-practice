using BoltFood.Core.Models.BaseModel;
using BoltFood.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Update(int id, T entity);
        public void Delete(int id);
        public T GetById(int id);
        public bool IfAny();
        public List<T> GetAll();
    }
}
