using Core.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositores.Base
{
    public class BaseRepistory<T> : IBaseRepistory<T> where T : BaseEntity
    {
        private readonly DbSet<T> _table;

        public BaseRepistory(AppDbContext context)
        {
            _table = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _table.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
          return  await _table.FindAsync(id);
        }

        public async  Task CreateAsync(T data)
        {
            _table.Add(data);
        }
        public  void Update (T data)
        {
            _table.Update(data);
        }
        public void Delete(T data)
        {
            _table.Remove(data);
        }

    }
}
