using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Developer : Employee
    {
        string programmingLanguage;
        public Developer(string name, int empid, double baseSalary, string programmingLanguage)
            : base(name, empid, baseSalary)
        {
            this.programmingLanguage = programmingLanguage;
        }
        public override double CalculateSalary()
        {
            return base.CalculateSalary();
        }
        public override void display()
        {
            Console.WriteLine($"Name: {name}, Employee ID: {empid}, Salary: {CalculateSalary()}, Programming Language: {programmingLanguage}");
        }
    }
}