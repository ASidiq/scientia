using ScientiaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Interfaces
{
    public interface IBookRepository: IRepository<Book, Author>
    {
    }
}
