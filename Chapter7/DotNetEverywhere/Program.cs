using System;
using static System.Console;

namespace DotNetEverywhere
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WriteLine("This app can run everywhere");
            var name = ReadLine();
            WriteLine($"Hi {name}");
        }
    }
}
