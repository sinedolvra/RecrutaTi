using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RecrutaTi.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(string id);
        IList<T> GetAll();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        void Save(T entity);
        void Remove(T entity);
    }
}