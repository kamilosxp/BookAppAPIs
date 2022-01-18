using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
