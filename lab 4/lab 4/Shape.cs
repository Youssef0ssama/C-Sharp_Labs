using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    internal class Shape
    {
        public virtual double Area()
        {
            return 0;
        }
    }
    internal class Circle : Shape
    {
        double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
    }
    internal class Rectangle : Shape
    {
        double length;
        double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public override double Area()
        {
            return length * width;
        }
    }
    internal class Triangle : Shape
    {
        double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double Area()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}