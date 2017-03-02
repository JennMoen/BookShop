using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookShop.Services;
using Microsoft.AspNetCore.Authorization;
using BookShop.Services.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private BookService _bService;

        public BooksController(BookService bs)
        {
            _bService = bs;
        }

        //returns /api/books
        [HttpGet]
        [Authorize]
        public IEnumerable<BookDTO> GetBooks()
        {
            return _bService.GetBooksForUser(User.Identity.Name);
        }

        //returns /api/books/book.Id
        [HttpGet("{id}")]
        public BookDTO GetById(int id)
        {
            return _bService.FindById(id, User.Identity.Name);
        }

        [HttpPost]
        public IActionResult PostBook([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bService.AddBook(book, User.Identity.Name);

            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] BookDTO book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bService.EditBook(book, User.Identity.Name);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy ="AdminOnly")]
        public IActionResult DeleteBook(BookDTO book, int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            book.Id = id;

            _bService.DeleteBook(book, User.Identity.Name);

            return Ok();
        }
    }
}
