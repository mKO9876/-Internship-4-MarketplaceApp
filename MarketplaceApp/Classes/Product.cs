using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    internal class Product
    {
        public Guid id;
        string name;
        string description;
        double price;
        bool inStock;
        Vendor ventor;

        public Product(string name, string description, double price, Vendor vendor)
        {
            id = Guid.NewGuid();
            this.name = name;  
            this.description = description;
            this.price = price;
            this.inStock = true;
            this.ventor = vendor;
        }


    }

}
