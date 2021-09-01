using System;
using static System.Console;

namespace Packt.Shared
{
    public class Employee : Person
    {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        public new void WriteConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dd/MM/yy} and hired on {HireDate:dd/MM/yy}.");
        }

        public override string ToString()
        {
            return $"{Name} is with code {EmployeeCode}";
        }
    }
}