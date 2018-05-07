using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Promotions.Classes
{
    public class Product
    {
        static int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public String Promotion { get; set; }

        public Product( String name, double price, String promotion)
        {
            ++Id;
            this.Name = name;
            this.Price = price;
            this.Promotion = promotion;
        }
    }
}