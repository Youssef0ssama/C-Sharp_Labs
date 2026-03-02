using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Date
    {
        int day;
        int month;
        int year;
        public Date() : this(2, 3, 2024) { }
        public Date(int year) : this(1, 1, year) { }
        public Date(int year, int month) : this(1, month, year) { }
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public void print()
        {
            Console.WriteLine($"{day}/{month}/{year}");
        }
    }
}