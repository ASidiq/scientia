using ScientiaWebAPI.Data;
using ScientiaWebAPI.Interfaces;
using ScientiaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Repository
{
    public class BookRepository : Repository<Book, Author>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext): base(dbContext)
        {

        }


    }
}
