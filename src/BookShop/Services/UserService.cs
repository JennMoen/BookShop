using BookShop.Infrastructure;
using BookShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class UserService
    {
        private UserRepository _urepo;

        public UserService(UserRepository ur)
        {
            _urepo = ur;
        }

        public IEnumerable<UserDTO> AdminViewUsers()
        {
            return (from u in _urepo.AdminViewUsers()
                    select new UserDTO()
                    {
                        UserName = u.UserName,
                        Books = (from b in u.Books
                                 select new BookDTO()
                                 {
                                     Author = b.Author,
                                     Title = b.Title,
                                     BookUrl = b.BookUrl,
                                     Id = b.Id,
                                     Price = b.Price,
                                     UserName = b.User.UserName


                                 }).ToList()

                    }).ToList();


        }
    }


}
