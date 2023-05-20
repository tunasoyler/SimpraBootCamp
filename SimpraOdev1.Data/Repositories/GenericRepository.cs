using Microsoft.EntityFrameworkCore;
using SimpraHW1.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpraHW1.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext db;

        public GenericRepository(DbContext _db)
        {
            db = _db;
        }

        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().Where(filter);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public Task Remove(T entity)
        {
            db.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().SingleOrDefaultAsync(filter);
        }
    }
}
