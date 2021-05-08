using ScientiaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScientiaWebAPI.Interfaces
{
    public interface IRepository<T, U>
    {
        T Create(T entity);
        
        IEnumerable<T> FindAll(Expression<Func<T, U>> expression);

        IEnumerable<T> FindByCondition(Expression<Func<T, U>> expression1, Expression<Func<T, bool>> expression2);

        T Update(T entity);

        void Delete(T entity);

        IEnumerable<T> Where(Expression<Func<T, bool>> expression2);
    }
}
