using System;
using System.Collections.Generic;
using System.Text;

namespace ITIEntities.Repo
{
    public interface IEntityRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
    internal class EntityRepo
    {
    }
}
