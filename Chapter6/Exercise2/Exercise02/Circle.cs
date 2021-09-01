using System;


namespace Exercise02
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Width = radius * 2;
            Height = radius * 2;
            Area = Math.PI * Math.Pow(radius, 2);
        }
    }
}