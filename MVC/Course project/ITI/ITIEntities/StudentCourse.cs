using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITIEntities
{
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Course))]
        public int CrsNo { get; set; }
        public int? Degree { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
