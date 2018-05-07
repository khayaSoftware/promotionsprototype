using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Promotions.Classes
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }

        public CartItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Total = this.Quantity * this.Product.Price;
        }

    }
}