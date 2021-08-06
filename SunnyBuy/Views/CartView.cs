using System;
using System.Linq;
using SunnyBuy.Services.CartServices;

namespace SunnyBuy.Views
{
    public class CartView
    {
        HomeView homeView = new HomeView();
        CartService cartService = new CartService();
        ProductsView productsView = new ProductsView();

        public void ShowCart()
        {
            Console.Clear();
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ------------------------------------------     Cart       -----------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();

            ProductsCart();

            Console.WriteLine(
                "                                              (1) Go to the Home \n \n" +
                "                                              (2) Buy now \n" +
                "                                              _________________"
                );
            Console.WriteLine();
            Console.Write("                                              Choose a option: ");
            var awnser = Convert.ToInt32(Console.ReadLine());

            CartOptions(awnser);
        }

        public void ProductsCart()
        {
            var cart = cartService.ShowProductsCart();
            var total = cart.Sum(a => a.Price);

            cart.ForEach
                (
                a =>
                    Console.WriteLine
                    (
                        $"       +           {a.Name} " +
                        $" ------------ R${ a.Price}\n"
                    )
                );

            Console.WriteLine($"       -----------------------------------------------------------------------------   TOTAL:   R${total} \n");
        }
    
        public void CartOptions(int awnser)
        {
            switch (awnser)
            {
                case 1:
                    Console.Clear();
                    homeView.ShowHome();
                    Console.WriteLine();
                    productsView.ProductsPageView();
                    break;
                case 2:
                    PurchaseView purchaseView = new PurchaseView();
                    Console.Clear();
                    purchaseView.PurchaseRegisterView();
                    break;
                default:
                    Console.Clear();
                    ShowCart();
                    break;
            }
        }
    }
}