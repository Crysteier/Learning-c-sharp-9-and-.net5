using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;

namespace WorkingWithDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int", "32 bit integer");
            keywords.Add("long", "64 bit integer");
            keywords.Add("float", "Single precision floating point number");
            WriteLine("keywords and their definitions");
            foreach (KeyValuePair<string, string> item in keywords)
            {
                WriteLine($"{item.Key}: {item.Value}");
            }
            WriteLine($"The definition of long is {keywords["long"]}");

            
        }
    }
}
