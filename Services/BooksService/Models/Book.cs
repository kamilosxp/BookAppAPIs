using System;
namespace BooksService.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string ImageURL { get; set; }
    }
}
