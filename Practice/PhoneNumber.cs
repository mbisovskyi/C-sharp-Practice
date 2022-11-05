using System;
using System.Linq;

namespace Practice
{
    class PhoneNumber
    {

        //METHODS

        //Main method to format a phone number with hidden digits except last four digits
        public static void HidePhoneNumber()
        {
            //Variables
            string[] symbols = new string[] { "/", "-", ".", " ", ",", "*", "_", "=", ":", ";", "#", "$", "%", "^", "&", "(", ")", "+", "!", "@", "`", "~", "|", "<", ">", "\\", "'", "\"" };


            string phoneNumberInput = GetPhoneNumber();
            string clearedPhoneNumber = ClearNumberOfSymbols(phoneNumberInput, symbols);
            bool isNumberValid = IsPhoneNumberValid(clearedPhoneNumber);
            if (isNumberValid)
            {
                { Console.WriteLine(FormattedPhoneNumber(clearedPhoneNumber)); }

            }
            else
            {
                Console.WriteLine($"\nEntered \"{phoneNumberInput}\" phone number is not valid!\n");
                HidePhoneNumber();
            }
        }

        //Getting user's phone number as a string.
        private static string GetPhoneNumber()
        {
            Console.WriteLine("Please, enter a phone number to hide.");
            Console.WriteLine("Number shouldn't contain letters and should be 10 digits long. Example: (111-222-3333): ");
            string phoneNumberInput = Console.ReadLine();
            return phoneNumberInput;
        }

        //Clearing phone number if contains symbols
        private static string ClearNumberOfSymbols(string phoneNumber, string[] symbols)
        {
            foreach (string symbol in symbols)
            {
                if (phoneNumber.IndexOf(symbol) != -1)
                {
                    phoneNumber = phoneNumber.Replace(symbol, "");
                }
            }
            return phoneNumber;
        }

        //Checking if phone number is valid (contains no letters).
        private static bool IsPhoneNumberValid(string phoneNumber)
        {
            if (phoneNumber.All(Char.IsDigit) == true && phoneNumber.Length == 10)
            {
                return true; }
            else
            {
                return false; }
        }

        //Formatting a phone number to hidden number.
        private static string FormattedPhoneNumber(string phoneNumber)
        {
            //Hidden digits
            string hiddenNumber = "###-###-";
            string originalPhoneNumber = "";

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (i == 3 || i == 6)
                {
                    originalPhoneNumber += "-";
                }
                originalPhoneNumber += phoneNumber[i];
                if (i > 5)
                {
                    hiddenNumber += phoneNumber[i];
                }
            }
            return $"Original phone number is: {originalPhoneNumber}\nHidden phone number: {hiddenNumber}";

        }
    }
}
