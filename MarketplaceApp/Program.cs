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
                    Console.WriteLine("0 - Buy product\n1 - Check all products\n2 - Find product based on specific category\n3 - Show your favorites\n4 - Add favorite product\n5 - Check your history\n6 - Check your returns\n7 - Log out");
                    string input = InputHelper.CheckUserInput("Option: ");
                    Product product;
                    Console.Clear();
                    switch (input)
                    {
                        case "0":
                            do
                            {
                                product = marketplace.FindProductByID();
                            } while (product == null);
                            marketplace.BuyProduct(product, customer);
                            break;
                        case "1":
                            Console.WriteLine("All products in stock: ");
                            marketplace.ShowAllProductsInStock();
                            break;
                        case "2":
                            string chosenCategory = ShowCategory.CheckCategoryExists("Which product category do you want to browse: ");
                            marketplace.ShowProductsByCategory(chosenCategory);
                            break;
                        case "3":
                            customer.ShowFavorites();
                            break;
                        case "4":
                            do
                            {
                                product = marketplace.FindProductByID();
                            } while (product == null);
                            customer.AddFavorite(product);
                            Console.WriteLine("Product stored in 'favorite products'");
                            break;
                        case "5":
                            Console.WriteLine("All transactions: ");
                            marketplace.CheckCustomersTransactions(customer);
                            break;
                        case "6":
                            Console.WriteLine("All returned product transactions: ");
                            marketplace.CheckCustomersTransactions(customer);
                            break;
                        case "7":
                            do
                            {
                                product = marketplace.FindProductByID();
                            } while (product == null);
                            marketplace.ReturnProduct(customer, product.id);
                            break;
                        case "8":
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
                    Console.WriteLine("1 - Check your products\n2 - Add new product\n3 - Add promo code\n4 - Change product price\n5 - Check profit\n6 - Show sold products based on category\n7 - Show profit in one period\n8 - Log out");
                    string input = InputHelper.CheckUserInput("Option: ");
                    Console.Clear();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("All your products: ");
                            marketplace.ShowVendorsProducts(vendor);
                            break;
                        case "2":
                            marketplace.AddNewProduct(vendor);
                            break;
                        case "3":
                            marketplace.AddPromoCode(vendor);
                            break;
                        case "4":
                            Product product = marketplace.FindProductByName(vendor);
                            double newPrice = InputHelper.ParseDouble("Insert new price: ");
                            product.ChangePrice(newPrice);
                            product.Print();
                            break;
                        case "5":
                            vendor.CheckProfit();
                            break;
                        case "6":
                            marketplace.ShowSoldProductWithCategory(vendor);
                            break;
                        case "7":
                            marketplace.ShowProfitInPeriod(vendor);
                            break;
                        case "8":
                            return;
                        default:
                            Console.WriteLine("Error: unknown input value");
                            break;
                    }
                }
            }
        }
    }
}
