using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Vendor : Person
    {

        //konstruktor
        public Vendor(string email, string username) {
            this.email = email;
            this.username = username;
        }
        void AddProduct()
        {

        }

        public override void Print()
        {
            Console.WriteLine($"{this.username} : {this.email}");
        }
    }
}
