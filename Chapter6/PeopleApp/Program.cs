using System.Reflection.PortableExecutable;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var harry = new Person { Name = "Harry" };
            var jill = new Person { Name = "Jill" };
            var mary = new Person { Name = "Mary" };

            var baby1 = mary.ProcreateWith(harry);
            baby1.Name = "Gary";

            //call static method
            var baby2 = Person.Procreate(harry, jill);
            // call an operator
            var baby3 = harry * mary;

            WriteLine($"{harry.Name} has {harry.Children.Count} children");
            WriteLine($"{mary.Name} has {mary.Children.Count} children");
            WriteLine($"{jill.Name} has {jill.Children.Count} children");
            WriteLine(format: "{0}'s first child is named \"{1}\".",
            arg0: harry.Name,
            arg1: harry.Children[0].Name);
            WriteLine($"5! is {Person.Factorial(5)}");

            //assign method to delegate
            harry.Shout += Harry_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();

            //----------interfaces cviko-----------------------
            Person[] people ={
            new Person{Name ="Simon"},
            new Person{Name ="Jenny"},
            new Person{Name ="Adam"},
            new Person{Name ="Richard"}
            };

            WriteLine("Initial list of poeple:");
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            WriteLine("Use Person's ICOmporable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            WriteLine("Use PersonComparers IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($" {person.Name}");
            }


            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");

            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string is: {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");

            var gt2 = new GenericThing<string>();
            gt2.Data = "asder";
            WriteLine($"GenericThing with string is: {gt2.Process("asder")}");

            string number1 = "4";
            WriteLine($"{number1} squared is {Squarer.Square<string>(number1)}");

            byte number2 = 3;
            WriteLine($"{number2} squared is {Squarer.Square<byte>(number2)}");

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.x},{dv1.y}) + ({dv2.x},{dv2.y}) = ({dv3.x},{dv3.y})");

            Employee john = new Employee
            {
                Name = "John",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteConsole();
            john.HireDate = new DateTime(2020, 11, 20);
            john.EmployeeCode = "JJ001";
            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
            WriteLine(john.ToString());

            Employee aliceInEmployee = new Employee
            {
                Name = "Alice",
                EmployeeCode = "AA123"
            };
            Person aliceInPerson = aliceInEmployee;
            aliceInPerson.WriteConsole();
            aliceInEmployee.WriteConsole();
            WriteLine(aliceInPerson.ToString());
            WriteLine(aliceInEmployee.ToString());


            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitAlice = (Employee)aliceInPerson;
            }
            try
            {
                john.TimeTrave(new DateTime(1999, 12, 31));
                john.TimeTrave(new DateTime(1950, 12, 22));
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";

            WriteLine($"{email1} is a valid e-mail: {StringExtensions.IsValidEmail(email1)}");
            WriteLine($"{email2} is a valid e-mail: {StringExtensions.IsValidEmail(email2)}");
            //-------------
            WriteLine($"{email1} is valid : {email1.IsValidEmail()}");
            WriteLine($"{email2} is valid : {email2.IsValidEmail()}");
        }

        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }



    }
}
