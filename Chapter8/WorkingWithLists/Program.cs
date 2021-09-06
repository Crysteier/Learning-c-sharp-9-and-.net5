using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;


namespace WorkingWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Bratislava");
            WriteLine("Initial list");
            foreach (string c in cities)
            {
                WriteLine($" {c}");
            }

            WriteLine($"The first city: {cities[0]}");
            WriteLine($"The last city: {cities[cities.Count - 1]}");
            cities.Insert(0, "Sydney");
            WriteLine("After inserting sydney at 0");
            foreach (string c in cities)
            {
                WriteLine($" {c}");
            }

            cities.RemoveAt(1);
            cities.Remove("Bratislava");
            WriteLine("After removing 2 cities");
            foreach (string c in cities)
            {
                WriteLine($" {c}");
            }

            var immutableCities = cities.ToImmutableList();
            var newList = immutableCities.Add("RIO");
            Write("Immutable list of cities:");
            foreach (string city in immutableCities)
            {
                Write($" {city}");
            }
            WriteLine();
            Write("New list of cities:");
            foreach (string city in newList)
            {
                Write($" {city}");
            }
            WriteLine();
        }
    }
}
