using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksService.Models;

namespace BooksService.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateUpdateProduct(Book book);
    }
}
