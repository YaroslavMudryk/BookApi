using AutoMapper;
using BookApi.Application.ViewModels.Books;
using BookApi.Domain.Intefaces;
using BookApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookViewModel> CreateBookAsync(BookCreateModel book)
        {
            var bookToInsert = _mapper.Map<Book>(book);

            bookToInsert.Photo = "{default_book_photo}";
            bookToInsert.CreatedAt = DateTime.Now;
            bookToInsert.CreatedBy = "Admin";
            bookToInsert.CreatedFromIP = "::1";

            var insertedBook = await _bookRepository.InsertAsync(bookToInsert);

            return _mapper.Map<BookViewModel>(insertedBook);
        }

        public async Task<BookViewModel> EditBookAsync(BookEditModel editModel)
        {
            var bookToEdit = await _bookRepository.GetAsync(x => x.Id == editModel.Id);

            if (bookToEdit == null)
                throw new Exception($"{nameof(bookToEdit)} not found");

            bookToEdit.Name = editModel.Name;
            bookToEdit.ISBN = editModel.ISBN;
            bookToEdit.Authors = editModel.Authors;
            bookToEdit.LastUpdatedAt = DateTime.Now;
            bookToEdit.LastUpdatedBy = "Admin";
            bookToEdit.LastUpdatedFromIP = "::1";

            var updatedBook = await _bookRepository.UpdateAsync(bookToEdit);

            return _mapper.Map<BookViewModel>(updatedBook);
        }

        public async Task<List<BookViewModel>> GetAllBooksAsync()
        {
            return _mapper.Map<List<BookViewModel>>(await _bookRepository.GetAllAsync());
        }

        public async Task<BookViewModel> GetBookByIdAsync(Guid id)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetAsync(x => x.Id == id));
        }

        public async Task<BookViewModel> RemoveBookAsync(Guid id)
        {
            var bookToRemove = await _bookRepository.GetAsync(x => x.Id == id);

            if (bookToRemove == null)
                throw new Exception($"{nameof(bookToRemove)} not found");

            var deletedBook = await _bookRepository.RemoveAsync(bookToRemove);

            return _mapper.Map<BookViewModel>(deletedBook);
        }
    }
}
