using System;

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
                { Console.WriteLine(ThreeChunksNumber(clearedPhoneNumber)); }

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
                    continue;
                }
                else
                {
                    phoneNumber.Replace(symbol, "");
                }
            }
            return phoneNumber;
        }

        //Checking if phone number is valid (contains no letters).
        private static bool IsPhoneNumberValid(string phoneNumber)
        {
            if (int.TryParse(phoneNumber, out int value) && phoneNumber.Length == 10)
            { return true; }
            else
            { return false; }
        }

        //Slice a phone number to 3 chunks.
        private static string ThreeChunksNumber(string phoneNumber)
        {
            //Hidden digits
            string hiddenDigits = "###-###-";

            //Getting a first chunk of a phone number.
            string chunkOne = "";
            for (int i = 0; i < 3; i++)
            { chunkOne += phoneNumber[i]; }
            chunkOne += "-";

            //Getting a second chunk of a phone number.
            string chunkTwo = "";
            for (int i = 3; i < 6; i++)
            { chunkTwo += phoneNumber[i]; }
            chunkTwo += "-";

            //Getting a third chunk of a phone number.
            string chunkThree = "";
            for (int i = 6; i < phoneNumber.Length; i++)
            { chunkThree += phoneNumber[i]; }

            //Original phone number
            string originalPhoneNumber = chunkOne + chunkTwo + chunkThree;

            return $"Original phone number is: {originalPhoneNumber}\nHidden phone number: {hiddenDigits + chunkThree}";

        }
    }
}
