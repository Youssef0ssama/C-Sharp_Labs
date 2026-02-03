using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Student
    {
        int age;
        public int Age
        {
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Student must be at least 18 years old.");

                }
                else
                {
                    age = value;
                }
            }
            get
            {
                return age;
            }
        }
        string name;
        public string Name { get; set; }
    }
}