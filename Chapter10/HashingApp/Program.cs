using System;
using static System.Console;
using CryptographyLib;

namespace HashingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registering Alice with Pa$$w0rd");
            var alice = Protector.Register("Alice", "Pa$$w0rd");

            WriteLine($"Name: {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");
            WriteLine($"Password (salted and hashed): {alice.SaltedHashedPassword}");
            WriteLine();

            Write("Enter a new user to register: ");
            string username = ReadLine();
            Write($"Enter a password for {username}: ");
            string password = ReadLine();

            var user = Protector.Register(username, password);

            WriteLine($"Name: {user.Name}");
            WriteLine($"Salt: {user.Salt}");
            WriteLine($"Password (salted and hashed): {user.SaltedHashedPassword}");

            bool correctPassword = false;
            while (!correctPassword)
            {
                Write("Enter a username to log in: ");
                string loginUserName = ReadLine();
                Write("enter a password to log in: ");
                string loginPassword = ReadLine();

                correctPassword = Protector.CheckPassword(loginUserName, loginPassword);

                if (correctPassword)
                {
                    WriteLine($"Correct! {loginUserName} has been logged in.");
                }
                else
                {
                    WriteLine("Invalid username or password, try again.");
                }
            }

        }
    }
}
