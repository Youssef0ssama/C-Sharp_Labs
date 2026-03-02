using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITIEntities
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [ForeignKey(nameof(Department))]
        public int Deptno { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<StudentCourse> StudentCourses { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
