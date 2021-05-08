using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository Authors { get; }

        IBookRepository Books { get;}

        void Save();
    }
}
