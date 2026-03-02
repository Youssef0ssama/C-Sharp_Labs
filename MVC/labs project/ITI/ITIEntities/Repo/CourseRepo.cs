using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ITIEntities.Repo
{
    public class CourseRepo : IEntityRepo<Course>
    {
        ITIContext context = new ITIContext();
        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }
        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }
        public List<Course> FindAll(System.Linq.Expressions.Expression<System.Func<Course, bool>> predicate)
        {
            return context.Courses.Where(predicate).ToList();
        }
        public void Add(Course entity)
        {
            context.Courses.Add(entity);
            context.SaveChanges();
        }
        public void Update(Course entity)
        {
            context.Courses.Update(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Courses.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}