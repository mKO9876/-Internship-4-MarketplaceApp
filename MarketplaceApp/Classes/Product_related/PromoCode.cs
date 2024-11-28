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
        public int discount;
        public Product productOnSale;

        public PromoCode(string c, int d, Product p)
        {
            this.code = c;
            this.discount = d;
            this.productOnSale = p; 
        }
    }
}
