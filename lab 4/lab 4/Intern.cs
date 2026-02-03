using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Intern : Employee
    {
        string university;
        int duration; // in months
        public Intern(string name, int empid, double baseSalary, string university, int duration)
            : base(name, empid, baseSalary)
        {
            this.university = university;
            this.duration = duration;
        }
        public override double CalculateSalary()
        {
            return base.CalculateSalary() * 0.5; // Interns get 50% of the base salary
        }
        public override void display()
        {
            Console.WriteLine($"Name: {name}, Employee ID: {empid}, Salary: {CalculateSalary()}, University: {university}, Duration: {duration} months");
        }

    }
}