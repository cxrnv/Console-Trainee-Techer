using System;
using System.Linq;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.CartServices;

namespace SunnyBuy.Views
{
    public class CartView
    {
        static protected readonly Context.Context context = new Context.Context();
        ClientLoggedIn loggedInclient = new ClientLoggedIn();
        HomeView homeView = new HomeView();
        ProductsView productsView = new ProductsView();
        CartService cartService = new CartService(context);

        public void ShowCart(ClientLoggedIn loggedInclient)
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
            Console.WriteLine("Type your id: ");
            var id = Convert.ToInt32(Console.ReadLine());

            var cart = cartService.ShowProductsCart(id);
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
                    productsView.ProductsPageView(loggedInclient);
                    break;
                case 2:
                    PurchaseView purchaseView = new PurchaseView();
                    Console.Clear();
                    purchaseView.PurchaseRegisterView();
                    break;
                default:
                    Console.Clear();
                    ShowCart(loggedInclient);
                    break;
            }
        }
    }
}