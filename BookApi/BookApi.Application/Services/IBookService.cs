using BookApi.Application.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Application.Services
{
    public interface IBookService
    {
        Task<BookViewModel> CreateBookAsync(BookCreateModel book);
        Task<BookViewModel> EditBookAsync(BookEditModel editModel);
        Task<BookViewModel> RemoveBookAsync(Guid id);
        Task<BookViewModel> GetBookByIdAsync(Guid id);
        Task<List<BookViewModel>> GetAllBooksAsync();
    }
}
