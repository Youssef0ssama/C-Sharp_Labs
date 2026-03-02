using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ITIEntities.Repo
{
    public class StudentCourseRepo : IEntityRepo<StudentCourse>
    {
        ITIContext context = new ITIContext();
        public List<StudentCourse> GetAll()
        {
            return context.StudentCourse.Include(sc => sc.Student).Include(sc => sc.Course).ToList();
        }
        public StudentCourse GetById(int id)
        {
            return context.StudentCourse.FirstOrDefault(sc => sc.StudentId == id);
        }
        public List<StudentCourse> FindAll(System.Linq.Expressions.Expression<System.Func<StudentCourse, bool>> predicate)
        {
            return context.StudentCourse.Where(predicate).ToList();
        }
        public void Add(StudentCourse entity)
        {
            context.StudentCourse.Add(entity);
            context.SaveChanges();
        }
        public void Update(StudentCourse entity)
        {
            context.StudentCourse.Update(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var ent = GetById(id);
            if (ent != null)
            {
                context.StudentCourse.Remove(ent);
                context.SaveChanges();
            }
        }
    }
}