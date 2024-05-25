using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<T?> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
    }
}
