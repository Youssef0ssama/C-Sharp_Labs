using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ITIEntities.Repo
{
    public class UserRepo : IEntityRepo<User>
    {
        ITIContext context = new ITIContext();
        public List<User> GetAll()
        {
            return context.Users.Include(u => u.Role).ToList();
        }
        public User GetById(int id)
        {
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
        }
        public List<User> FindAll(System.Linq.Expressions.Expression<System.Func<User, bool>> predicate)
        {
            return context.Users.Include(u => u.Role).Where(predicate).ToList();
        }
        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        public void Update(User entity)
        {
            context.Users.Update(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Users.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}