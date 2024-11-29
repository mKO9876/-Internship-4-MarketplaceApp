using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public class Transaction
    {
        public Guid id;
        public double price;
        public Customer customer;
        public Vendor vendor;
        public DateTime dateCreated;

        public Transaction(Product p, Customer c, Vendor v)
        {
            this.id = p.id;
            this.price = p.price;
            this.customer = c;
            this.vendor = v;
            DateTime created = DateTime.Now;
        }

        public void Print()
        {
            Console.WriteLine($"product id: {this.id}, buyer: {this.customer.name}, seller: {this.vendor.name}, date & time: {this.dateCreated.ToString("dd/MM/yy, HH:mm")}");
        }

    }
}
