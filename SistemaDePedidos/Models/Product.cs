using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }

        public Product()
        {

        }

        public Product(string Name, double Price, string Desc)
        {
            this.Name = Name;
            this.Price = Price;
            this.Desc = Desc;
        }

        public double FinalPrice()
        {
            return this.Price * 1.21;
        }

    }
}
