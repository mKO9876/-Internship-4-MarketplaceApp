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

        Dictionary<string, (int, Product)> promoCodes = new Dictionary<string, (int, Product)>();
        //List<Transactions> transactions;

        public bool VendorEmailUsed(string email) //izmijenit 
        {

            if (vendors.Count == 0) return false;
            foreach (var vendor in vendors)
            {
                if (vendor.email == email) return true;
            }
            return false;
        }

        public bool CustomerEmailUsed(string email)
        {
            if (customers.Count == 0) return false;
            foreach (var customer in customers)
            {
                if (customer.email == email) return true;
            }
            return false;
        }

        public void ShowAllInStock()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("There are no products.");
                return;
            }

            foreach (var product in products)
            {
                if (product.inStock) product.Print();
            }
        }

        public void FilterByCategory(string category)
        {
            foreach (var product in products)
            {
                if (product.category.CheckCategoryEqual(category)) product.Print();
            }
        }

        //vendor ubacuje promotivne kodove
        public void AddPromoCode(Vendor vendor)
        {
            string pCode;
            do
            {
                pCode = InputHelper.CheckUserInput("Insert promo code: ");
                if (!promoCodes.ContainsKey(pCode)) Console.WriteLine("Promo code already exists, please input unique promo code");
            } while (!promoCodes.ContainsKey(pCode));
            int discount = InputHelper.CheckInt("Insert discount (without %): ");
            Product productOnSale;
            do
            {
                productOnSale = FindProductByName();
                if (productOnSale.vendor.email != vendor.email) Console.WriteLine("You are not the owner of this product, insert promo code for your products only");
            } while (productOnSale.vendor.email != vendor.email);
             

            promoCodes.Add(pCode, (discount, productOnSale));
            Console.WriteLine("Promo code successfuly added.");
        }

        public Product FindProductByName()
        {
            string productName; 
            while(true)
            {
                productName = InputHelper.CheckUserInput("Insert product name: ");
                foreach (var product in products)
                {
                    if(product.name == productName) return product;
                }
            }
        }


    }
}
