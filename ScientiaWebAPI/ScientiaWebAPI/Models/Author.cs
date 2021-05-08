using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Models
{
    public class Author
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public string AuthorPicUrl { get; set; }
    }
}
