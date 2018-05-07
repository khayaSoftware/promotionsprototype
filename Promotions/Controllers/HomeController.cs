using Promotions.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promotions.Controllers
{
    public class HomeController : Controller
    {
        public List<CartItem> Cart = new List<CartItem>();

        public void makeCart()
        {
            //ideally this data would be read from the database.
            Cart.Add(new CartItem(new Product("A", 20.00, "Buy 1 Get 1 Free"), 2));
            Cart.Add(new CartItem(new Product("B", 4.00, "3 for 10 Euro"), 3));
            Cart.Add(new CartItem(new Product("C", 2.00, ""), 5));
        }
        public ActionResult Index()
        {
            makeCart();
            return View(Cart);
        }

        public ActionResult Checkout()
        {
            makeCart();
            foreach (CartItem item in Cart)
            {
                if(item.Product.Promotion.Equals("Buy 1 Get 1 Free") && item.Quantity > 1)
                {
                    item.Total -= item.Product.Price;
                }
                else if (item.Product.Promotion.Equals("3 for 10 Euro") && item.Quantity >= 3)
                {
                    item.Total -= (item.Product.Price * 3);
                    item.Total += 10;
                }
            }
            ViewData["Cart"] = Cart;
            return View(Cart);
        }

        
    }
}