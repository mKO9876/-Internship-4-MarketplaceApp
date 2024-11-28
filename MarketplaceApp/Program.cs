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
                Console.WriteLine("Options:\n1 - Customer\n2 - Vendor\n3 - Exit");
                string userInput = InputHelper.CheckUserInput("Select one option: ");
                switch (userInput)
                {
                    case "1":
                        CustomerAccessData();
                        break;
                    case "2":
                        VendorAccessData();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;
                }

            }


            void CustomerAccessData()
            {
                Console.Clear();
                Console.WriteLine("You choose: Customer options");
                Console.WriteLine("Options:\n1 - Sign Up\n2 - Log In\n3 - Return");
                string userInput = InputHelper.CheckUserInput("Select one option: ");
                bool isCustomer = true;
                switch (userInput)
                {
                    case "1":
                        SignUp(isCustomer);
                        //OTVORIT MU MARKETPLACE
                        break;
                    case "2":
                        LogIn(isCustomer);
                        //OTVORIT MU MARKETPLACE
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;

                }

            }

            void VendorAccessData()
            {
                Console.Clear();
                Console.WriteLine("You choose: Vendor options");
                Console.WriteLine("Options:\n1 - Sign Up\n2 - Log In\n3 - Return");
                string userInput = InputHelper.CheckUserInput("Select one option: ");
                bool isCustomer = false;
                switch (userInput)
                {
                    case "1":
                        SignUp(isCustomer);
                        //OTVORIT MU MARKETPLACE
                        break;
                    case "2":
                        LogIn(isCustomer);
                        //OTVORIT MU MARKETPLACE
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;

                }
            }

            void SignUp(bool isCustomer)
            {
                Console.Clear();
                Console.WriteLine("Create new account.");
                string username = InputHelper.CheckUserInput("Insert username:  ");
                string email;
                bool emailUsed;
                if (isCustomer)
                {
                    do
                    {
                        email = InputHelper.CheckEmail("Insert email: ");
                        emailUsed = marketplace.CustomerEmailUsed(email);
                        if (emailUsed) Console.WriteLine("Email in use, try different email.");
                    } while (emailUsed);

                    double balance = InputHelper.CheckBalance("Insert your balance: ");

                    Customer customer = new Customer(username, email, balance);
                    //marketplace.Add(customer);
                    Console.WriteLine("New customer added: ");
                    customer.Print();
                    //ODE POZOVI ZA CUSTOMER
                }
                else
                {
                    do
                    {
                        email = InputHelper.CheckEmail("Insert email: ");
                        emailUsed = marketplace.VendorEmailUsed(email);
                        if (emailUsed) Console.WriteLine("Email in use, try different email.");
                    } while (emailUsed);

                    Vendor vendor = new Vendor(username, email);
                    //marketplace.Add(customer);
                    Console.WriteLine("New vendor added: ");
                    vendor.Print();
                    //ODE POZOVI ZA VENDOR
                }

            }

            void LogIn(bool isCustomer)
            {
                Console.Clear();
                Console.WriteLine("Log In");
                string email;
                bool emailUsed;
                if (isCustomer)
                {
                    do
                    {
                        email = InputHelper.CheckEmail("Insert email: ");
                        emailUsed = marketplace.CustomerEmailUsed(email);
                        if (!emailUsed) Console.WriteLine("Email does not exist, try again.");
                    } while (!emailUsed);
                    //marketplace.Add(customer);
                    Console.WriteLine("Customer found ");
                    //ODE POZOVI ZA CUSTOMER
                }
                else
                {
                    do
                    {
                        email = InputHelper.CheckEmail("Insert email: ");
                        emailUsed = marketplace.VendorEmailUsed(email);
                        if (!emailUsed) Console.WriteLine("Email does not exist, try again.");
                    } while (!emailUsed);

                    Console.WriteLine("Vendor found.");
                    //ODE POZOVI ZA VENDOR
                }
            }
        }
    }
}
