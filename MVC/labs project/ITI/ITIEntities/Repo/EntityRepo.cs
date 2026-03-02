using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace ITIEntities.Repo
{
    public interface IEntityRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> FindAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
    internal class EntityRepo
    {
    }
}
