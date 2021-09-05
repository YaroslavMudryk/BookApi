using BookApi.Application.Services;
using BookApi.Application.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookApi.Web.Controllers.V1
{
    [ApiVersion("1.0")]
    public class BooksController : ApiBaseController
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            return Ok(await _bookService.GetBookByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateModel bookModel)
        {
            return Ok(await _bookService.CreateBookAsync(bookModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookEditModel bookEdit)
        {
            bookEdit.Id = id;
            return Ok(await _bookService.EditBookAsync(bookEdit));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            return Ok(await _bookService.RemoveBookAsync(id));
        }
    }
}
