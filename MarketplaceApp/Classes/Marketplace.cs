using MarketplaceApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Marketplace
    {
        List<Customer> customers = new List<Customer>();
        List<Vendor> vendors = new List<Vendor>();
        List<Product> products = new List<Product>();
        //List<Transactions> transactions;

        public void SignUp() {
            Console.Clear();
            Console.WriteLine("Create new customer account.");
            string username = InputHelper.CheckUserInput("Insert username:  ");
            string email;
            Customer customerData;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                customerData = EmailUsed(email);
                if (customerData!=null) Console.WriteLine("Email in use, try different email.");
            } while (customerData != null);

            double balance = InputHelper.CheckBalance("Insert your balance: ");

            Customer customer = new Customer(username, email, balance);
            customers.Add(customer);
            Console.WriteLine("New customer added: ");
            customer.Print();
        }

        public void LogIn()
        {
            Console.Clear();
            string email;
            Customer customerData;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                customerData = EmailUsed(email);
                if (customerData == null) Console.WriteLine("Email doesn't exist, try different one.");
            } while (customerData == null);
            Console.WriteLine("Welcome back!");
            customerData.Print();
        }

        

        Customer EmailUsed(string email)
        {
            if (customers.Count == 0) return null;
            foreach (var customer in customers)
            {
                if (customer.email == email) return customer;
            }
            return null;
        }
    }
}
