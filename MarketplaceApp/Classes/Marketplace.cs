using MarketplaceApp.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketplaceApp
{
    public class Marketplace
    {
        List<Customer> customers = new List<Customer>();
        List<Vendor> vendors = new List<Vendor>();
        List<Product> products = new List<Product>();
        List<Transaction> transactions = new List<Transaction>();
        List<PromoCode> promoCodes = new List<PromoCode>();

        //customer methods
        public void AddNewCustomer(Customer c) { customers.Add(c); }
        public Customer CustomerEmailUsed(string email, string name)
        {
            if (customers.Count == 0) return null;
            foreach (var customer in customers)
            {
                if (customer.email == email && customer.name == name) return customer;
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
                if (product.category.CheckCategoryEqual(category) && product.inStock) product.Print();
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
        public void ShowProfitInPeriod(Vendor vendor)
        {
            DateTime minDate = InputHelper.HandleDateTime("Insert date (dd-MM-yyyy): ");
            foreach (var transaction in transactions)
            {
                if(transaction.vendor.email == vendor.email && transaction.dateCreated >= minDate ) transaction.Print();
            }
        }

        public void AddPromoCode(Vendor vendor)
        {
            Console.Clear();
            string pCode;
            do
            {
                pCode = InputHelper.CheckUserInput("Insert promo code: ");
                if (PromoCodeExists(pCode)) Console.WriteLine("Promo code already exists, please input unique promo code");
            } while (PromoCodeExists(pCode));
            int discount = InputHelper.ParseInt("Insert discount (without %): ");
            Product productOnSale = FindProductByName(vendor);

            PromoCode newPromo = new PromoCode(pCode, discount, productOnSale);
            promoCodes.Add(newPromo);
            Console.WriteLine("Promo code added: ");
            newPromo.Print();
        }
        bool PromoCodeExists(string code)
        {
            if (promoCodes.Count == 0) return false;
            foreach (var promoCode in promoCodes)
            {
                if (promoCode.code == code) return true;
            }
            return false;
        }


        public Product FindProductByName(Vendor vendor)
        {
            Console.Clear();
            string productName;
            while (true)
            {
                productName = InputHelper.CheckUserInput("Insert product name: ");
                foreach (var product in products)
                {
                    if (product.name == productName && product.vendor.email == vendor.email) return product;
                }
                Console.WriteLine("Try again");
            }
        }
        public void ShowSoldProductWithCategory(Vendor vendor)
        {
            Category chosenCategory = ShowCategory.ReturnCategory("Choose category you want to filter with: ");
            foreach (var product in products)
            {
                if (product.vendor.email == vendor.email && !product.inStock && product.category == chosenCategory) product.Print();
            }
        }
        public void ShowVendorsProducts(Vendor vendor)
        {
            foreach (var product in products)
            {
                if (product.vendor.email == vendor.email) product.Print();
            }
        }
        public void AddNewProduct(Vendor vendor)
        {
            string name = InputHelper.CheckUserInput("Insert product name: ");
            string description = InputHelper.CheckUserInput("Insert product description: ");
            int price = InputHelper.ParseInt("Insert price: ");
            Category productCategory = ShowCategory.ReturnCategory("Choose category for product: ");
            Product newProduct = new Product(name, description, price, vendor, productCategory);
            products.Add(newProduct);
            newProduct.Print();
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
