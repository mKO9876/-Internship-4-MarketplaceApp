using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    internal class Customer : Person
    {
        double balance;
        List<Product> productHistory;
        List<Product> productFavorite;

        public Customer(string n, string e, double b) {
            this.username = n;
            this.email = e; 
            this.balance = b;
            this.productHistory = new List<Product>();
            this.productFavorite = new List<Product>();
        }

        void BuyProduct()
        {
            //provjeri može li se kupiti: postoji li u dućanu i imaju li dovoljno novaca
        }

        public override void Print()
        {
            Console.WriteLine($"{this.username} : {this.email} - Balance: {this.balance} euro");
        }

        
    }
}
