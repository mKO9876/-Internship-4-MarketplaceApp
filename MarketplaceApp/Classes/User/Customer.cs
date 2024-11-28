using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Customer 
    {
        double balance;
        public string name;
        public string email;
        List<Product> productHistory;
        List<Product> productFavorite;

        public Customer(string n, string e, double b) {
            this.name = n;
            this.email = e; 
            this.balance = b;
            this.productHistory = new List<Product>();
            this.productFavorite = new List<Product>();
        }

        void BuyProduct()
        {
            //provjeri može li se kupiti: postoji li u dućanu i imaju li dovoljno novaca
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
    }
}
