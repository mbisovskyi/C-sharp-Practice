using System;
using System.Collections.Generic;


namespace Practice
{
    internal class AppOne
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter your phone number: ");
            string phoneNumberInput = Console.ReadLine();
            Console.WriteLine(HidePhoneNumber(phoneNumberInput));
        }

        static string HidePhoneNumber(string phoneNumber)
        {
            string[] separatingSymbols = new string[] { "/", "-", ".", " ", ",", "*" };
            phoneNumber = phoneNumber.Replace(separatingSymbols[1], "");
            return phoneNumber;
        }
    }
}
