using System;

namespace Practice
{
    class PhoneNumber
    {

        //METHODS
        public static void HidePhoneNumber()
        {
            //Variables
            string phoneNumberInput;
            string clearedPhoneNumber;
            bool doesContainSymbols;
            bool isNumberValid;
            string[] symbols = new string[] { "/", "-", ".", " ", ",", "*", "_" };

            phoneNumberInput = GetPhoneNumber();
            doesContainSymbols = DoesContainSymbols(phoneNumberInput, symbols);
            if (doesContainSymbols)
            {
                clearedPhoneNumber = ClearedPhoneNumber(phoneNumberInput, symbols);
                isNumberValid = IsPhoneNumberValid(clearedPhoneNumber);

                if (!isNumberValid)
                {
                    Console.WriteLine($"\nEntered \"{phoneNumberInput}\" phone number is not valid!\n");
                    HidePhoneNumber(); 
                }
                else
                { Console.WriteLine(ThreeChunksNumber(clearedPhoneNumber)); }
            }
            else
            {
                isNumberValid = IsPhoneNumberValid(phoneNumberInput);

                if (!isNumberValid)
                { HidePhoneNumber(); }
                else
                { Console.WriteLine(ThreeChunksNumber(phoneNumberInput)); }
            }


        }

        //Getting user's phone number as a string.
        private static string GetPhoneNumber()
        {
            Console.WriteLine("Please, enter your phone number.");
            Console.WriteLine("Number shouldn't contain letters and should be 10 digits long. Example: (111-222-3333): ");
            string phoneNumberInput = Console.ReadLine();
            return phoneNumberInput;
        }

        //Formatting phone number to clear out of any possible entered symbols.
        private static string ClearedPhoneNumber(string phoneNumber, string[] symbols)
        {
            if (phoneNumber.Contains(symbols[0]))
            { phoneNumber = phoneNumber.Replace(symbols[0], ""); }

            if (phoneNumber.Contains(symbols[1]))
            { phoneNumber = phoneNumber.Replace(symbols[1], ""); }

            if (phoneNumber.Contains(symbols[2]))
            { phoneNumber = phoneNumber.Replace(symbols[2], ""); }

            if (phoneNumber.Contains(symbols[3]))
            { phoneNumber = phoneNumber.Replace(symbols[3], ""); }

            if (phoneNumber.Contains(symbols[4]))
            { phoneNumber = phoneNumber.Replace(symbols[4], ""); }

            if (phoneNumber.Contains(symbols[5]))
            { phoneNumber = phoneNumber.Replace(symbols[5], ""); }

            if (phoneNumber.Contains(symbols[6]))
            { phoneNumber = phoneNumber.Replace(symbols[6], ""); }
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
            //Getting a first chunk of a phone number.
            string chunkOne = "";
            for (int i = 0; i < 3; i++)
            { chunkOne += phoneNumber[i]; }
            string hiddenChunkOne = "###-";

            //Getting a second chunk of a phone number.
            string chunkTwo = "";
            for (int i = 3; i < 6; i++)
            { chunkTwo += phoneNumber[i]; }
            string hiddenChunkTwo = "###-";

            //Getting a third chunk of a phone number.
            string chunkThree = "";
            for (int i = 6; i < phoneNumber.Length; i++)
            { chunkThree += phoneNumber[i]; }

            return $"Original phone number is: {chunkOne + "-" + chunkTwo + "-" + chunkThree}\nHidden phone number: {hiddenChunkOne + hiddenChunkTwo + chunkThree}";

        }

        //Check if phone number input contains symbols.
        private static bool DoesContainSymbols(string phoneNumber, string[] symbols)
        {
            bool value = true;
            foreach (string symbol in symbols)
            {
                if (phoneNumber.IndexOf(symbol) != -1)
                { value = false; }
                else
                { value = true; }
            }
            return value;
        }
    }
}
