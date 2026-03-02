using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITIEntities.Repo
{
    public class DepartmentRepo : IEntityRepo<Department>
    {
        ITIContext context = new ITIContext();
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.Find(id);
        }
        public void Add(Department Department)
        {
            context.Departments.Add(Department);
            context.SaveChanges();
        }
        public void Update(Department Department)
        {
            context.Departments.Update(Department);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Departments.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
