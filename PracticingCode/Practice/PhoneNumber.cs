using System;
using System.Windows.Forms;

namespace Practice
{
    class PhoneNumber
    {

        //METHODS
        public static void HidePhoneNumber()
        {
            string phoneNumberInput;
            string clearedPhoneNumber;

            phoneNumberInput = GetPhoneNumber();
            clearedPhoneNumber = ClearedPhoneNumber(phoneNumberInput);
            if (!IsPhoneNumberValid(clearedPhoneNumber))
            {
                Console.WriteLine("Number is not valid!");
                Console.WriteLine("Do you want to restart? Y/N");
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "y" || userAnswer == "yes")
                {
                    HidePhoneNumber();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            { Console.WriteLine(ThreeChunksNumber(clearedPhoneNumber)); }

        }

        //Getting user's phone number as a string.
        private static string GetPhoneNumber()
        {

            Console.WriteLine("Please, enter your phone number: ");
            string phoneNumberInput = Console.ReadLine();
            return phoneNumberInput;
        }

        //Formatting phone number to clear out of any possible entered symbols.
        private static string ClearedPhoneNumber(string phoneNumber)
        {
            string[] separatingSymbols = new string[] { "/", "-", ".", " ", ",", "*", "_" };
            if (phoneNumber.Contains(separatingSymbols[0]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[0], ""); }

            if (phoneNumber.Contains(separatingSymbols[1]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[1], ""); }

            if (phoneNumber.Contains(separatingSymbols[2]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[2], ""); }

            if (phoneNumber.Contains(separatingSymbols[3]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[3], ""); }

            if (phoneNumber.Contains(separatingSymbols[4]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[4], ""); }

            if (phoneNumber.Contains(separatingSymbols[5]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[5], ""); }

            if (phoneNumber.Contains(separatingSymbols[6]))
            { phoneNumber = phoneNumber.Replace(separatingSymbols[6], ""); }
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
    }
}
