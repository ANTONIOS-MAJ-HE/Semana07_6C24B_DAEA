using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }

        public Product() { }

        public Product(int id, string name, decimal price, int stock)
        {
            this.product_id = id;
            this.name = name;
            this.price = price;
            this.stock = stock;
        }
    }
}
