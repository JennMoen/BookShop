using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Infrastructure
{
    public class BookRepository
    {
        public ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //return a list of books for a given user
        public IQueryable<Book> GetBooksForUser(string userName)
        {
            return from b in _db.Books
                   where b.User.UserName == userName
                   select b;
        }

        //get a single book by its unique Id
        public IQueryable<Book> GetBookById(int id, string userName)
        {
            return from b in _db.Books
                   where b.Id == id && b.User.UserName == userName
                   select b;

        }

        //add a book (duh)
        public void AddBook(Book book, string user)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        //Edit a book
        public void EditBook()
        {
            _db.SaveChanges();
        }

        //delete a book
        public void Remove(Book dbBook, string user)
        {
            _db.Books.Remove(dbBook);
            _db.SaveChanges();
        }


    }
}
