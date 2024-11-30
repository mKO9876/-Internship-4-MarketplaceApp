using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Classes
{
    public static class InputHelper
    {
        public static string CheckEmail(string text)
        {
            string email;
            do
            {
                email = CheckUserInput(text);
                if (!email.Contains("@") || email.Length < 3) Console.WriteLine("Input didn't fill requirement: min. length = 3, has to contain @.");
            } while (!email.Contains("@") || email.Length < 3);

            return email;
        }

        public static string CheckUserInput(string text)
        {
            string input;
            do
            {
                Console.Write(text);
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) Console.WriteLine("Input cannot be empty.");
            } while (String.IsNullOrEmpty(input));
            Console.Clear();
            return input;
        }

        public static double ParseDouble(string text)
        {
            Console.Clear();
            double balance;
            string input;
            do
            {
                input = CheckUserInput(text);
                if (!double.TryParse(input, out balance)) Console.WriteLine("Unable to parse to number. Try Again.");
                if (balance <= 0) Console.WriteLine("Input cannot be less than 0.");
            } while (!double.TryParse(input, out balance) || balance <= 0);
            return balance;

        }

        //public static int ParseInt(string text)
        //{
        //    string input;
        //    int number;
        //    do
        //    {
        //        input = CheckUserInput(text);
        //        if (!int.TryParse(input, out number)) Console.WriteLine("Unable to parse to number. Try Again.");
        //        if (number < 0) Console.WriteLine("Input cannot be less than 0.");
        //    } while (!int.TryParse(input, out number) || number < 0);
        //    return number;
        //}

        public static DateTime HandleDateTime(string text)
        {
            DateTime date;
            string input;
            do
            {
                input = CheckUserInput(text);
                if (!DateTime.TryParseExact(input, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out date))
                    Console.WriteLine("Invalid input, try again.");

            } while (!DateTime.TryParseExact(input, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out date));

            return date;
        }

       
    }
}
