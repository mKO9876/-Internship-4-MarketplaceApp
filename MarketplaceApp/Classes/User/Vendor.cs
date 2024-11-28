using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Vendor
    {

        public string name;
        public string email;
        public double profit;
        public Vendor(string email, string username) {
            this.email = email;
            this.name = username;
            this.profit = 0;
        }

        public void Print()
        {
            Console.WriteLine($"{this.name} : {this.email}");
        }

        public void CheckProfit()
        {
            Console.WriteLine("Your profit is: ", this.profit.ToString());
        }
    }
}
