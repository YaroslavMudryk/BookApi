using AutoMapper;
using BookApi.Application.Services;
using BookApi.Domain.Intefaces;
using BookApi.Infrastructure.Data.EntityFramework.Context;
using BookApi.Infrastructure.Data.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookApi.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddBookApiAutoMapper();

            services.AddDbContext<BookDbContext>(opt =>
            {
                opt.UseSqlite(connectionString);
            });

            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IBookService, BookService>();
        }

        public static void AddBookApiAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookApi.Application.Mapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
