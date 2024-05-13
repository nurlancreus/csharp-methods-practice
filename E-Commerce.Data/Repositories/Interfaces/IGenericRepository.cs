using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public T? GetById(int id);
        public List<T> GetAll();
    }
}
