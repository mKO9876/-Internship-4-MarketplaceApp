using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Product
    {
        public Guid id;
        public string name;
        string description;
        public double price;
        public bool inStock;
        public Category category;
        public Vendor vendor;

        public Product(string name, string description, double price, Vendor vendor, Category category)
        {
            id = Guid.NewGuid();
            this.name = name;
            this.description = description;
            this.price = price;
            this.inStock = true;
            this.vendor = vendor;
            this.category = category;
        }

        public void ChangePrice(double price)
        {
            this.price = price;
        }

        public void ChangeStockValue()
        {
            this.inStock = !this.inStock;
        }

        public void Print()
        {
            Console.WriteLine($"-> ID: {this.id}, name: {this.name}, description: {this.description}, category: {this.category.ReturnString()}, price:{this.price}");
        }
    }

}
