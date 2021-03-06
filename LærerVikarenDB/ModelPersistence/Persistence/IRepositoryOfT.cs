using System;
using System.Collections.Generic;
using System.Text;

namespace ModelPersistence.Persistence
{
    public interface IRepository<T>
    {
        void Add(T entity); // create
        IEnumerable<T> GetAll(); // read
        void GetById(int id);
        void Update(T entity); // update
        void Remove(T entity); // delete
    }
}
