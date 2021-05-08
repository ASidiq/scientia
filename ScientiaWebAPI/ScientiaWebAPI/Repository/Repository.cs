using Microsoft.EntityFrameworkCore;
using ScientiaWebAPI.Data;
using ScientiaWebAPI.Interfaces;
using ScientiaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Repository
{
    public class Repository<T, U> : IRepository<T , U> 
        where T: class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }

        public Repository(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }

        public IEnumerable<T> FindAll(Expression<Func<T, U>> expression)
        {
            return RepositoryContext.Set<T>().Include<T, U>(expression).AsNoTracking();
        }


        public IEnumerable<T> FindByCondition(Expression<Func<T, U>> expression, Expression<Func<T, bool>> expression2)
        {
            return RepositoryContext.Set<T>().Include<T, U>(expression).Where(expression2).AsNoTracking();
        }

        public T Update(T entity)
        {
            return RepositoryContext.Set<T>().Update(entity).Entity;
        }
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression2)
        {
            return RepositoryContext.Set<T>().Where(expression2);
        }
    }
}
