using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services.Models
{
    public class UserDTO
    {
        public string UserName { get; set; }

        public IList<BookDTO> Books { get; set; }

    }
}
