using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotions;
using Promotions.Classes;
using Promotions.Controllers;

namespace Promotions.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public List<CartItem> Cart = new List<CartItem>();

        public void makeCart()
        {
            //ideally this data would be read from the database.
            Cart.Add(new CartItem(new Product("A", 20.00, "Buy 1 Get 1 Free"), 2));
            Cart.Add(new CartItem(new Product("B", 4.00, "3 for 10 Euro"), 3));
            Cart.Add(new CartItem(new Product("C", 2.00, ""), 5));
        }

        [TestMethod]
        public void Contact()
        {
            makeCart();
            foreach (CartItem item in Cart)
            {
                if (item.Product.Promotion.Equals("Buy 1 Get 1 Free") && item.Quantity > 1)
                {
                    item.Total -= item.Product.Price;
                }
                else if (item.Product.Promotion.Equals("3 for 10 Euro") && item.Quantity >= 3)
                {
                    item.Total -= (item.Product.Price * 3);
                    item.Total += 10;
                }
            }

            HomeController controller = new HomeController();

            var result = controller.Checkout() as ViewResult;

            List<CartItem> TestCart = result.ViewData.Model as List<CartItem>;


            for (int i = 0; i < Cart.Count; i++)
            {
                Assert.AreEqual(TestCart[i].Total, Cart[i].Total);
            }
                
        }
    }
}
