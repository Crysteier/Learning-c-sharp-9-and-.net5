using System;
using System.Security.Cryptography;
using CryptographyLib;
using static System.Console;


namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message that you want to encrypt: ");
            string message = ReadLine();

            Write("Enter a password: ");
            string password = ReadLine();


            string cryptoText = Protector.Encrypt(message, password);

            WriteLine($"Encrypted text: {cryptoText}");

            Write("Enter the password: ");
            string password2 = ReadLine();

            try
            {
                string cleaText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text: {cleaText}");
            }
            catch (CryptographicException ex)
            {
                WriteLine($"You entered the wrong password!\nMore details: {ex.Message}");
            }catch(Exception ex){
                WriteLine($"Non-cryptographic exception: {ex.GetType().Name}, {ex.Message}");
            }
        }
    }
}
