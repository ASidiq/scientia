using ScientiaWebAPI.Data;
using ScientiaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        IAuthorRepository _authors;

        IBookRepository _books;

      
        public IAuthorRepository Authors {
            get
            {
                if (_authors == null)
                {
                    _authors = new AuthorRepository(_repoContext);
                }
                return _authors;
            }

        }

        public IBookRepository Books {
            get
            {
                if (_books == null)
                {
                    _books = new BookRepository(_repoContext);
                }
                return _books;
            }
        }

        void IRepositoryWrapper.Save()
        {

            _repoContext.SaveChanges();
        }
    }
}
