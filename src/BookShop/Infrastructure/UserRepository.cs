using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Infrastructure
{
    public class UserRepository
    {
        public ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public IQueryable<ApplicationUser> GetUser(string name)
        {
            return from u in _db.Users
                   //"where"=keyword for filtering data
                   where u.UserName == name
                   select u;
        }

        public IQueryable<ApplicationUser> AdminViewUsers()
        {
            return from u in _db.Users
                   select u;
        }

    }
}
