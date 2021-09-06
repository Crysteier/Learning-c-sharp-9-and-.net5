using System.Security.AccessControl;
using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace WorkingWithRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter your age: ");
            string input = "44";

            var ageChecker = new Regex(@"^\d+$");
            if (ageChecker.IsMatch(input))
            {
                WriteLine("Thank you dude");
            }
            else
            {
                  WriteLine($"This is not a valid age: {input}");
            }

            string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock,Stock and twoSmokingBarrels\"";
            string[] filmsDumb = films.Split(',');
            WriteLine("Dumb attempt at splitting:");
            foreach (string film in filmsDumb)
            {
                WriteLine(film);
            }
            var csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|{^,\"]*))\"?(?=,|$)");
            MatchCollection filmsSmart = csv.Matches(films);
            foreach (Match film in filmsSmart)
            {
                WriteLine(film.Groups[2].Value);
            }
        }
    }
}
