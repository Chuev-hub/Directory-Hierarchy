using AutoMapper;
using Dir.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir.BLL.Services
{
    public class GenericService<T, T1> : IService<T, T1> where T : class where T1 : class
    {
        protected IRepository<T1> Repository { get; set; }
        protected IMapper Mapper { get; set; }
        public GenericService()
        {
            MapperConfiguration config = new MapperConfiguration(con => con.CreateMap<T, T1>().ReverseMap());
            Mapper = new Mapper(config);
        }

        public virtual async Task AddAsync(T entity)
        {
            await Repository.AddAsync(Mapper.Map<T, T1>(entity));
            await Repository.SaveChanges();
        }

        public async Task<T> Get(int id) => Mapper.Map<T1, T>(await Repository.GetAsync(id));

        public async Task<IEnumerable<T>> GetAll() => Mapper.Map<IEnumerable<T1>, IEnumerable<T>>(await Repository.GetAll());

        public async Task RemoveAsync()
        {
            await Repository.RemoveAsync();
            await Repository.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            await Repository.UpdateAsync(Mapper.Map<T, T1>(entity));
            await Repository.SaveChanges();
        }

        public async Task RemoveAtAsync(int id)
        {
            await Repository.RemoveAtAsync(await Repository.GetAsync(id));
            await Repository.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            var list = Mapper.Map<IEnumerable<T>, IEnumerable<T1>>(entities);
            await Repository.AddRangeAsync(list);
            await Repository.SaveChanges();
        }
    }
}
