using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Models.View
{
    public class AuthorViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }

        public string AuthorPicUrl { get; set; }
    }
}
