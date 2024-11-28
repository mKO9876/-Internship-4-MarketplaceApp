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

        List<PromoCode> promoCodes = new List<PromoCode>();

        //customer methods
        public void AddNewCustomer(Customer c) { customers.Add(c); }
        public Customer CustomerEmailUsed(string email)
        {
            if (customers.Count == 0) return null;
            foreach (var customer in customers)
            {
                if (customer.email == email) return customer;
            }
            return null;
        }

        public void ShowAllProductsInStock()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("There are no products. Please wait unitl vendors put some products.");
                return;
            }

            foreach (var product in products)
            {
                if (product.inStock) product.Print();
            }
        }

        public void ShowProductsByCategory(string category)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("There are no products at this point. Please return later.");
                return;
            }
            foreach (var product in products)
            {
                if (product.category.CheckCategoryEqual(category)) product.Print();
            }
        }


        //vendor methods
        public void AddNewVendor(Vendor v) { vendors.Add(v); }
        public Vendor VendorEmailUsed(string email) 
        {

            if (vendors.Count == 0) return null;
            foreach (var vendor in vendors)
            {
                if (vendor.email == email) return vendor;
            }
            return null;
        }

        public void AddPromoCode(Vendor vendor)
        {
            string pCode;
            do
            {
                pCode = InputHelper.CheckUserInput("Insert promo code: ");
                if (!PromoCodeExists(pCode)) Console.WriteLine("Promo code already exists, please input unique promo code");
            } while (!PromoCodeExists(pCode));
            int discount = InputHelper.CheckInt("Insert discount (without %): ");
            Product productOnSale;
            do
            {
                productOnSale = FindProductByName();
                if (productOnSale.vendor.email != vendor.email) Console.WriteLine("You are not the owner of this product, insert promo code for your products only");
            } while (productOnSale.vendor.email != vendor.email);

            PromoCode newPromo = new PromoCode(pCode, discount, productOnSale);

            promoCodes.Add(newPromo);
            Console.WriteLine("Promo code successfuly added.");
        }

        public Product FindProductByName()
        {
            string productName;
            while (true)
            {
                productName = InputHelper.CheckUserInput("Insert product name: ");
                foreach (var product in products)
                {
                    if (product.name == productName) return product;
                }
            }
        }

        public bool PromoCodeExists(string code)
        {
            foreach (var promoCode in promoCodes)
            {
                if (promoCode.code == code) return true;
            }
            return false;
        }

        //public void ReturnItem(Transaction transaction)
        //{
        //    customerReturning
        //    foreach(var customer in customers)
        //    {
        //        if (customer.email == transaction.customerEmail)
        //        {

        //        }

        //}
    }
}
