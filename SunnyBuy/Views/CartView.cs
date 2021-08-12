using System;
using System.Linq;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.UsersServices;

namespace SunnyBuy.Views
{
    public class CartView
    {
        HomeView homeView = new HomeView();
        ProductsView productsView = new ProductsView();
        CartService cartService = new CartService(context);
        ClientLoggedIn loggedInclient = new ClientLoggedIn();
        ClientService clientService = new ClientService(context);
        static protected readonly Context.Context context = new Context.Context();

        public void ShowCart(int clientId )
        {
            Console.Clear();
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ------------------------------------------     Cart       -----------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();

            ProductsCart(clientId);

            Console.WriteLine(
                "                                              (1) Go to the Home \n \n" +
                "                                              (2) Buy now \n" +
                "                                              _________________"
                );
            Console.WriteLine();
            Console.Write("                                              Choose a option: ");
            var awnser = Convert.ToInt32(Console.ReadLine());

            CartOptions(awnser, clientId);
        }

        public void ProductsCart(int clientId)
        {
            Console.WriteLine("       Your cart: ");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            var cart = cartService.ShowProductsCart(clientId);

            var client = clientService.GetClientsId(clientId);

            client.ForEach
                (
                c => Console.WriteLine
                    (
                           $"        {c.Name}\n \n" +
                           $"        {c.Email}\n \n" +
                           $"        {c.Phone}\n \n" +
                           $"        Send to: {c.Address}\n")
                );


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
    
        public void CartOptions(int awnser, int clientId)
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
                    purchaseView.PurchaseRegisterView(clientId);
                    break;
                default:
                    Console.Clear();
                    ShowCart(clientId);
                    break;
            }
        }
    }
}