using BookApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookApi.Domain.Intefaces
{
    public interface IRepository<T> where T: class
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetListAsync(Func<T, bool> predicate);
        Task<T> GetAsync(Func<T, bool> predicate);
    }
}