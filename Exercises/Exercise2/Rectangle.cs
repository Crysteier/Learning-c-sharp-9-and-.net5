using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise2
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
           Area = Width * Height;
        }
        public double Height { get; set; }
        public double Width { get; set; }
        public readonly double Area;

    }
}