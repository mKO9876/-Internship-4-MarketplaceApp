using MarketplaceApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Marketplace marketplace = new Marketplace();
            Console.WriteLine("WELCOME TO A MARKETPLACE APP!");
            while (true)
            {
                Console.WriteLine("Options:\n1 - User options\n2 - Vendor options\n3 - Exit");
                string userInput = CheckUserInput("Select one option: ");
                switch (userInput)
                {
                    case "1":
                        UserOptions();
                        break;
                    case "2":
                        VendorOptions();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;
                }

            }


            void UserOptions()
            {
                Console.Clear();
                Console.WriteLine("You choose: User options");
                Console.WriteLine("Options:\n1 - Sign Up\n2 - Log In\n3 - Return");
                string userInput = CheckUserInput("Select one option: ");
                switch (userInput)
                {
                    case "1":
                        marketplace.SignUp();
                        //OTVORIT MU MARKETPLACE
                        break;
                    case "2":
                        marketplace.LogIn();
                        //OTVORIT MU MARKETPLACE
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;

                }

            }

            void VendorOptions()
            {
                Console.Clear();
            }

            string CheckUserInput(string text)
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
        }
    }
}
