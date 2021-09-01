using System.Drawing;
using System;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square("red", 6);
            WriteLine($"Square is {square.Color} colored and width: {square.Width} height: {square.Height} and area is {square.Area}");
            var c = new Circle(2.5);
            WriteLine($"Circle = H: {c.Height} W:{c.Width} Area:{c.Area}");
            var r = new Rectangle(3, 4.5);
            WriteLine($"Rectangle = H:{r.Height} W: {r.Width} Area:{r.Area}");
        }
    }
}
