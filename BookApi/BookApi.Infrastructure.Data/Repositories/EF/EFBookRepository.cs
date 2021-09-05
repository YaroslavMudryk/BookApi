using BookApi.Domain.Intefaces;
using BookApi.Domain.Models;
using BookApi.Infrastructure.Data.EntityFramework.Context;
namespace BookApi.Infrastructure.Data.Repositories.EF
{
    public class EFBookRepository : EFRepository<Book>, IBookRepository
    {
        public EFBookRepository(BookDbContext db) : base(db)
        {

        }
    }
}