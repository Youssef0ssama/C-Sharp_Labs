using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class Rectangle
    {
        public double Width
        {
            get; set;
        }
        public double Height
        {
            get; set;
        }
        public string Color
        {
            get; set;
        } = "White";
        public int Id
        {
            get;
        }
        public double Area
        {
            get
            {
                return Width * Height;
            }
        }
    }
}