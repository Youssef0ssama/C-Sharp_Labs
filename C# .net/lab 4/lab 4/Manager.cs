using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Manager : Employee
    {
        double bonus;
        int teamsize;
        public Manager(string name, int empid, double baseSalary, int teamsize, double bonus) : base(name, empid, baseSalary)
        {
            this.bonus = bonus;
            this.teamsize = teamsize;
        }
        public override double CalculateSalary()
        {
            return base.CalculateSalary() + bonus;
        }
    }
}