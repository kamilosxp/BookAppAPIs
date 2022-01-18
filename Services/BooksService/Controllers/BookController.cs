using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksService.Controllers.Providers;
using BooksService.Models;
using BooksService.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksService.Controllers
{
    [Route("api/v1/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            var books = await _bookRepository.GetBooks();
            return books;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] Book book)
        {
            var isbn = book.ISBN;
            book.Image = await GetPhotoImage(isbn);

            var content = await _bookRepository.CreateUpdateProduct(book);

            return content;
        }

        private async Task<byte[]> GetPhotoImage(string isbn)
        {
            var apiAddress = "https://covers.openlibrary.org/";
            var bookDataProvider = new BookDataProvider(apiAddress);

            return await bookDataProvider.GetBookImage(isbn, CoverPhotoSize.MEDIUM);
        }
    }
}
