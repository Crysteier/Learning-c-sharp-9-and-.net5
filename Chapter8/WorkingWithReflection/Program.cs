using System.Linq;
using System.Runtime.CompilerServices;
using System;
using static System.Console;
using System.Reflection;

namespace WorkingWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata: ");
            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($" Full name: {assembly.FullName}");
            WriteLine($" Location: {assembly.Location}");
            var attributes = assembly.GetCustomAttributes();
            WriteLine($" Attributes:");
            foreach (var item in attributes)
            {
                WriteLine($" {item.GetType()}");
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($" Version: {version.InformationalVersion}");
            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($" Company: {company.Company}");

            WriteLine();
            WriteLine($"* Types:");
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                WriteLine();
                WriteLine($"Type: {type.FullName}");
                MemberInfo[] members = type.GetMembers();

                foreach (var member in members)
                {
                    WriteLine($"{member.MemberType}: {member.Name} {member.DeclaringType.Name}");
                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
                    foreach (var coder in coders)
                    {
                        WriteLine($"-> Modified by {coder.Coder} on {coder.LastModified.ToShortDateString()}");
                    }
                }
            }
        }

        [Coder("Mark Price", "22 August 2019")]
        [Coder("Adam Moricz", "15 June 2015")]
        public static void DoStuff() { }
    }
}
