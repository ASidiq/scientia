using ScientiaWebAPI.Models;
using System.Collections.Generic;

namespace ScientiaWebAPI.Interfaces
{
    public interface IAuthorRepository : IRepository<Author, List<Book>>
    {
    }
}
