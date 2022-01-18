using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksService.Context;
using BooksService.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BookRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Book> CreateUpdateProduct(Book book)
        {
            var checkIsExist = await _databaseContext.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

            if(checkIsExist == null)
                await _databaseContext.Books.AddAsync(book);

            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public Task<Book> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            List<Book> booksList = await _databaseContext.Books.ToListAsync();
            return booksList;
        }
    }
}
