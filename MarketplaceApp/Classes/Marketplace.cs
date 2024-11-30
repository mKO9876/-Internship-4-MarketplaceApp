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

        public void BuyProduct(Product product, Customer customer)
        {
            if (product.inStock)
            {
                if (customer.balance >= product.price)
                {
                    foreach (var prod in products)
                    {
                        if (prod.id == product.id)
                        {
                            double newPrice = UsePromoCode(product);
                            prod.ChangeStockValue();
                            customer.balance -= prod.price;
                            bool isReturned = false;
                            Transaction t = new Transaction(prod, customer, prod.vendor, isReturned, newPrice);
                            transactions.Add(t);
                            customer.BuyProduct(newPrice);
                            break;
                        }

                    }
                }
                else Console.WriteLine($"You do not have enough money to buy this product. Your balance: {customer.balance} and product price: {product.price}");
            }
            else Console.WriteLine("Product you're trying to buy isn't available anymore.");
        }

        public double UsePromoCode(Product product)
        {
            string input = InputHelper.CheckUserInput("Add promo code (add 'n' if there are no promo codes): : ");
            if (input != "n" || input != "N")
            {
                foreach(var item in promoCodes)
                {
                    if (item.code == input) {
                        if (item.productOnSale.id == product.id)
                        {
                            return product.price - product.price*item.discount/100;
                        } 
                    }
                }
                Console.WriteLine($"Couldn't find '{input}' promo code");
            }
            return product.price;
        }
        public void ReturnProduct(Customer customer, Guid productId)
        {
            foreach (var product in products)
            {
                Console.WriteLine("PRODUCT ID: ", product.id.ToString());
                if (product.id == productId)
                {
                    if (product.inStock)
                    {
                        bool isReturned = true;
                        Transaction newTransaction = new Transaction(product, customer, product.vendor, isReturned, product.price);
                        transactions.Add(newTransaction);
                        product.inStock = true;
                        ReturnMoney(customer, product);
                    }
                }
            }
        }

        public void ReturnMoney(Customer customer, Product product)
        {
            foreach (var item in customers)
            {
                if (item.email == customer.email && item.name == customer.name)
                {
                    double returnAmountCustomer = product.price - product.price * 80 / 100;
                    double returnAmountVendor = product.price - product.price * 95 / 100;
                    item.balance = returnAmountCustomer;
                    Console.WriteLine("Item returned");
                    return;
                }
            }
        }
        public Product FindProductByID()
        {
            string productId = InputHelper.CheckUserInput("Insert product id: ");
            foreach (var product in products)
            {
                if (product.id.ToString() == productId)
                {
                    if (product.inStock)
                    {
                        Console.Write("Product found: ");
                        product.Print();
                        return product;
                    }
                    else
                    {
                        Console.WriteLine("That product is not available right now.");
                        return null;
                    }
                }
            }
            Console.WriteLine("No product with id ", productId);
            return null;

        }
        public void CheckCustomersTransactions(Customer customer)
        {
            bool checkIfPrinted = false;
            foreach (var transaction in transactions)
            {
                if (transaction.customer == customer)
                {
                    checkIfPrinted = true;
                    transaction.Print();
                }
            }

            if (checkIfPrinted) Console.WriteLine("No transactions.");
        }

        public void CheckCustomersTransactionsReturned(Customer customer)
        {
            bool checkIfPrinted = false;
            foreach (var transaction in transactions)
            {
                if (transaction.customer == customer && transaction.isReturned == true)
                {
                    checkIfPrinted = true;
                    transaction.Print();
                }
            }

            if (checkIfPrinted) Console.WriteLine("No transactions.");
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
                if (transaction.vendor.email == vendor.email && transaction.dateCreated >= minDate) transaction.Print();
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
            double discount = InputHelper.ParseDouble("Insert discount (without %): ");
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
            double price = InputHelper.ParseDouble("Insert price: ");
            Category productCategory = ShowCategory.ReturnCategory("Choose category for product: ");
            Product newProduct = new Product(name, description, price, vendor, productCategory);
            products.Add(newProduct);
            newProduct.Print();
        }
    }
}
