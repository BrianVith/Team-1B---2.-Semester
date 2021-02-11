using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovies.Repos
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T obj);
        void Update(T obj, T newValues);
        void Delete(T obj);
    }
}
