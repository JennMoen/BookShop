using BookShop.Infrastructure;
using BookShop.Models;
using BookShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class BookService
    {
        private UserRepository _uRepo;
        private BookRepository _bookRepo;

        public BookService(UserRepository ur, BookRepository br)
        {
            _uRepo = ur;
            _bookRepo = br;
        }

        public IList<BookDTO> GetBooksForUser(string userName)
        {
            return (from b in _bookRepo.GetBooksForUser(userName)
                    select new BookDTO()
                    {
                        Id = b.Id,
                        Author= b.Author,
                        Title = b.Title,
                        BookUrl = b.BookUrl,
                        Price = b.Price,
                        UserName = b.User.UserName
                        
                    }).ToList();
        }

        public BookDTO FindById(int id, string user)
        {
            return (from b in _bookRepo.GetBookById(id, user)
                    select new BookDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Author = b.Author,
                        Price = b.Price,
                        BookUrl = b.BookUrl
                    }).FirstOrDefault();
        }

        public void AddBook(BookDTO book, string currentUser)
        {
            Book dbBook = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                BookUrl = book.BookUrl,
                Price = book.Price,
                UserId = _uRepo.GetUser(currentUser).First().Id
            };

            _bookRepo.AddBook(dbBook, currentUser);
        }

        public void EditBook(BookDTO book, string currentUser)
        {
            Book dbBook = _bookRepo.GetBookById(book.Id, currentUser).FirstOrDefault();

            dbBook.Author = book.Author;
            dbBook.Title = book.Title;
            dbBook.Price = book.Price;
            dbBook.BookUrl = book.BookUrl;

            _bookRepo.EditBook();
        }

        public void DeleteBook(BookDTO book, string currentUser)
        {
            _bookRepo.Remove(_bookRepo.GetBookById(book.Id, currentUser).First(), currentUser);
        }

    }
}
