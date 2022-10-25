using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task UpdateAsync(T entity);
        public Task AddAsync(T entity); 
        public Task AddRangeAsync(IEnumerable<T> entiies); 
        public Task RemoveAsync();
        public Task RemoveAtAsync(T entity);
        public Task SaveChanges();
    }
}
