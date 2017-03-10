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
    public class UsersController : Controller
    {
        private UserService _uService;
        
        public UsersController(UserService us)
        {
            _uService = us;
        }

        [HttpGet]
        [Authorize(Policy="AdminOnly")]
        public IEnumerable<UserDTO> AdminViewUsers()
        {
            return _uService.AdminViewUsers();
        }
    }
}
