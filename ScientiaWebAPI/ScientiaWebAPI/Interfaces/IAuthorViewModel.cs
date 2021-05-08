using ScientiaWebAPI.Models;
using System.Collections.Generic;

namespace ScientiaWebAPI.Interfaces
{
    public interface IAuthorViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }

        public string AuthorPicUrl { get; set; }
    }
}
