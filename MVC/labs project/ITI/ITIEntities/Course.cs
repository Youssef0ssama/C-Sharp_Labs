using System;
using System.Collections.Generic;
using System.Text;

namespace ITIEntities
{
    public class Course
    {
        public int CrsId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<StudentCourse> StudentCourses { get; set; }
    }
}
