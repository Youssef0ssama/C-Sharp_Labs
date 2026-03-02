using ITIEntities.Data;
using System.Collections.Generic;
using System.Linq;

namespace ITIEntities.Repo
{
    public class RoleRepo : IEntityRepo<Role>
    {
        ITIContext context = new ITIContext();
        public List<Role> GetAll()
        {
            return context.Roles.ToList();
        }
        public Role GetById(int id)
        {
            return context.Roles.Find(id);
        }
        public List<Role> FindAll(System.Linq.Expressions.Expression<System.Func<Role, bool>> predicate)
        {
            return context.Roles.Where(predicate).ToList();
        }
        public void Add(Role entity)
        {
            context.Roles.Add(entity);
            context.SaveChanges();
        }
        public void Update(Role entity)
        {
            context.Roles.Update(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Roles.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}