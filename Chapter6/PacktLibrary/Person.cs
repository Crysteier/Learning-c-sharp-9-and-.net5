using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        public void WriteConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public void TimeTrave(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode kekw!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}");
            }
        }

        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        //static method to multiply
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        //instance method of multiplhy
        public Person ProcreateWith(Person partnet)
        {
            return Procreate(this, partnet);
        }

        //method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localnumber)
            {
                if (localnumber < 1)
                {
                    return 1;
                }
                return localnumber * localFactorial(localnumber - 1);
            }
        }

        public int MethodIWantToCall(string input)
        {
            return input.Length;
        }

        //event delegate field
        public event EventHandler Shout;

        //data field
        public int AngerLevel;

        //method
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                //if something is listening
                if (Shout != null)
                {
                    //then call the delegate
                    Shout(this, EventArgs.Empty);
                }

                //inline check if null then call......
                //Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }
    }
}


