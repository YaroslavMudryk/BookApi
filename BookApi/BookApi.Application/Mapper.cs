using AutoMapper;
using BookApi.Application.ViewModels.Books;
using BookApi.Domain.Models;

namespace BookApi.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookCreateModel, Book>();
            CreateMap<BookEditModel, Book>();
        }
    }
}