using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Classes
{
    public class PromoCode
    {
        public string code;
        public double discount;
        public Product productOnSale;

        public PromoCode(string c, double d, Product p)
        {
            this.code = c;
            this.discount = d;
            this.productOnSale = p; 
        }

        public void Print()
        {
            Console.WriteLine($"code: {this.code}, discount: {this.discount}, product on sale: {this.productOnSale.name}");
        }
    }
}
