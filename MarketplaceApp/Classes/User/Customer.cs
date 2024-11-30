using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Customer 
    {
        public double balance;
        public string name;
        public string email;
        List<Product> productFavorite;

        public Customer(string n, string e, double b) {
            this.name = n;
            this.email = e; 
            this.balance = b;
            this.productFavorite = new List<Product>();
        }

        public void AddFavorite(Product p)
        {
            productFavorite.Add(p);
            Console.Write("Product added to favorites: ");
            p.Print();
        }
        public void Print()
        {
            Console.WriteLine($"{this.name} : {this.email} - Balance: {this.balance} euro");
        }

        public void ShowFavorites()
        {
            if (productFavorite.Count == 0)
            {
                Console.WriteLine("There are no favorite products. Browse to find some.");
                return;
            }
            foreach (var item in productFavorite) item.Print();

        }

        public void BuyProduct(double price)
        {
            this.balance -= price;
            Console.WriteLine("Transaction completed");
        }
    }
}
