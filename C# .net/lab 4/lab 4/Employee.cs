using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Employee
    {
        protected string name;
        protected int empid;
        protected double baseSalary;
        public Employee(string name, int empid, double baseSalary)
        {
            this.name = name;
            this.empid = empid;
            this.baseSalary = baseSalary;
        }
        public virtual double CalculateSalary()
        {
            return baseSalary;
        }
        public virtual void display()
        {
            Console.WriteLine($"Name: {name}, Employee ID: {empid}, Salary: {CalculateSalary()}");
        }

    }
}