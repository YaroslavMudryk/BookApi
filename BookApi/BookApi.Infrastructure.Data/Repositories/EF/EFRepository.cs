using BookApi.Domain.Intefaces;
using BookApi.Infrastructure.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookApi.Infrastructure.Data.Repositories.EF
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly BookDbContext db;
        protected readonly DbSet<T> dbSet;
        public EFRepository(BookDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await db.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);

            await db.SaveChangesAsync();

            return entity;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            db.Set<T>().Remove(entity);

            await db.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            db.Set<T>().Update(entity);

            await db.SaveChangesAsync();

            return entity;
        }
    }
}
