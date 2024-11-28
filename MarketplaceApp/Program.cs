using MarketplaceApp.Classes;
using MarketplaceApp.Classes.Static___helper;
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
                        CustomerAccessAccount();
                        break;
                    case "2":
                        VendorAccessAccount();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;
                }

            }


            void CustomerAccessAccount()
            {
                Console.Clear();
                Console.WriteLine("You choose: Customer options");
                Console.WriteLine("Options:\n1 - Sign Up\n2 - Log In\n3 - Return");
                string userInput = InputHelper.CheckUserInput("Select one option: ");
                Customer customer;
                switch (userInput)
                {
                    case "1":
                        customer = AccessAccount.CustomerSignUp(marketplace);
                        CustomerMarketplace(customer);
                        break;
                    case "2":
                        customer = AccessAccount.CustomerLogIn(marketplace);
                        CustomerMarketplace(customer);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;

                }

            }

            void VendorAccessAccount()
            {
                Console.Clear();
                Console.WriteLine("You choose: Vendor options");
                Console.WriteLine("Options:\n1 - Sign Up\n2 - Log In\n3 - Return");
                string userInput = InputHelper.CheckUserInput("Select one option: ");
                Vendor vendor;
                switch (userInput)
                {
                    case "1":
                        vendor = AccessAccount.VendorSignUp(marketplace);
                        VendorMarketplace(vendor);
                        break;
                    case "2":
                        vendor = AccessAccount.VendorLogIn(marketplace);
                        VendorMarketplace(vendor);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Error: unknown input value");
                        break;

                }
            }

            void CustomerMarketplace(Customer customer)
            {
                while (true)
                {
                    Console.WriteLine("1 - Check all products\n2 - Find product based on specific category\n3 - Check your favorites\n4 - Check your history\n5 - Check your returns\n6 - Log out");
                    string input = InputHelper.CheckUserInput("Option: ");
                    Console.Clear();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("All products in stock: ");
                            marketplace.ShowAllProductsInStock();
                            break;
                        case "2":
                            string chosenCategory;
                            do
                            {
                                Console.WriteLine("Categories:\n- electronics, \n- clothing, \n- books, \n- dairy products, \n- meat, \n- fruits and vegetables, \n- snacks, \n- baked goods, \n- household");
                                chosenCategory = InputHelper.CheckUserInput("Which product category do you want to browse: ");
                                if (!ShowCategory.CheckCategoryExists(chosenCategory)) Console.WriteLine("Category does not exist, try again.");
                            } while (!ShowCategory.CheckCategoryExists(chosenCategory));
                            marketplace.ShowProductsByCategory(chosenCategory);
                            break;
                        case "3":
                            customer.ShowFavorites();
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Error: unknown input value");
                            break;
                    }
                }
            }

            void VendorMarketplace(Vendor vendor)
            {
                while (true)
                {
                    Console.WriteLine("1 - Check your products\n2 - Add new product\n3 - Add promo code\n4 - Change product price\n5 - Check profit\n6 - Log out");
                    string input = InputHelper.CheckUserInput("Option: ");
                    Console.Clear();
                    
                }
            }
        }
    }
}
