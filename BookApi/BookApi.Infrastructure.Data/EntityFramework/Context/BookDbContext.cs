using BookApi.Domain.Models;
using BookApi.Infrastructure.Data.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
namespace BookApi.Infrastructure.Data.EntityFramework.Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}