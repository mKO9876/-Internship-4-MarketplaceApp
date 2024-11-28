using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Classes.Static___helper
{
    public static class AccessAccount
    {
        public static Customer CustomerSignUp(Marketplace market)
        {
            Console.Clear();
            Console.WriteLine("Create new account.");
            string name = InputHelper.CheckUserInput("Insert name:  ");
            Customer newCustomer;
            string email;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                newCustomer = market.CustomerEmailUsed(email);
                if (newCustomer != null) Console.WriteLine("Email in use, try different email.");
            } while (newCustomer != null);

            double balance = InputHelper.CheckBalance("Insert your balance: ");

            newCustomer = new Customer(name, email, balance);
            market.AddNewCustomer(newCustomer);
            Console.WriteLine("New customer added: ");
            newCustomer.Print();
            return newCustomer;
        }

        public static Customer CustomerLogIn(Marketplace market)
        {
            Console.Clear();
            Console.WriteLine("Log In");
            string email;
            Customer existingCustomer;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                existingCustomer = market.CustomerEmailUsed(email);
                if (existingCustomer == null) Console.WriteLine("Email does not exist, try again.");
            } while (existingCustomer == null);
            Console.WriteLine("Customer found.");
            existingCustomer.Print();
            return existingCustomer;

        }

        public static Vendor VendorSignUp(Marketplace market)
        {
            Console.Clear();
            Console.WriteLine("Create new account.");
            string name = InputHelper.CheckUserInput("Insert name:  ");
            string email;
            Vendor newVendor;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                newVendor = market.VendorEmailUsed(email);
                if (newVendor != null) Console.WriteLine("Email in use, try different email.");
            } while (newVendor != null);

            newVendor = new Vendor(name, email);
            market.AddNewVendor(newVendor);
            Console.WriteLine("New vendor added: ");
            newVendor.Print();
            return newVendor;
        }

        public static Vendor VendorLogIn(Marketplace market)
        {
            Console.Clear();
            Console.WriteLine("Log In");
            string email;
            Vendor existingVendor;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                existingVendor = market.VendorEmailUsed(email);
                if (existingVendor == null) Console.WriteLine("Email does not exist, try again.");
            } while (existingVendor == null);

            Console.WriteLine("Vendor found.");
            existingVendor.Print();
            return existingVendor;
        }
    }
}
