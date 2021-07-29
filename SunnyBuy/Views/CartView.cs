using SunnyBuy.Services.CartServices;
using System;

namespace SunnyBuy.Views
{
    public class CartView
    {
        CartService cartService = new CartService();
        public void ShowCart()
        {
            Console.WriteLine("_______________________________________");
            Console.WriteLine("-------------------Cart----------------");

            var teste = cartService.ShowProductsCart();

            teste.ForEach(a => Console.WriteLine(a.Name));
        }    
    }
}
