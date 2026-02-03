using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class GradeBook
    {
        double[] grades;
        public GradeBook(int size)
        {
            grades = new double[size];
        }
        public double this[int index]
        {
            set
            {
                grades[index] = value;
            }
            get
            {
                return grades[index];
            }
        }

    }
}