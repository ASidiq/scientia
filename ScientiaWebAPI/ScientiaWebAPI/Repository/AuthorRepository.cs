using ScientiaWebAPI.Data;
using ScientiaWebAPI.Interfaces;
using ScientiaWebAPI.Models;
using System.Collections.Generic;

namespace ScientiaWebAPI.Repository
{
    public class AuthorRepository : Repository<Author, List<Book>>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


    }
}
