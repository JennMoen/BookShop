using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services.Models
{
    public class BookDTO
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string BookUrl { get; set; }

        public decimal Price { get; set; }

        public string UserName { get; set; }

    }
}
