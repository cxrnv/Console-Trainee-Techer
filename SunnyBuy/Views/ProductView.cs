using System;
using SunnyBuy.Services.CartServices;
using SunnyBuy.LoggedIn;

namespace SunnyBuy.Views
{
    public class ProductView
    {
        Context.Context context = new Context.Context();
        ClientLoggedIn loggedInclient = new ClientLoggedIn();

        public void CardProductCategory(string category)
        {
            Console.WriteLine("            ____________________________________________________");
            Console.WriteLine();
            Console.WriteLine($"                                 Home > Category ");
            Console.WriteLine("            ____________________________________________________");
            Console.WriteLine();
            Console.WriteLine($"            ---------------------- {category} -------------------");
            Console.WriteLine("            ____________________________________________________");
            Console.WriteLine();
        }

        public void CardProduct(string name, float price, string detail, int quantity)
        {
            Console.WriteLine("           __________________________________________________________________________\n");
            Console.WriteLine($"           -------------------------------- {name} ------------------------------\n");
            Console.WriteLine($"                            Name: {name}");
            Console.WriteLine($"                            Price: {price}");
            Console.WriteLine($"                            Detail: {detail}");
            Console.WriteLine($"                            Quantity: {quantity} \n" +
                $"           __________________________________________________________________________\n");
            Console.WriteLine();
        }

        public void AddProductCardView(string awnser, int productId, int clientId)
        {
            HomeView homeView = new HomeView();
            CartView cartView = new CartView();
            CartService cartService = new CartService(context);
            ProductsView productsView = new ProductsView();

            switch (awnser)
            {
                case "Y":
                    //make a link to the view of sign up or login 
                    //pass the LoggedIn.Client.To HERE to add to the cart with the id of the client
                    Console.WriteLine("Type your id");
                    var id = Convert.ToInt32(Console.ReadLine());

                    if (cartService.AddProductCart(/*loggedInclient.ClientId*/ id, productId))
                        Console.WriteLine("                                      Added with success!  ");
                    else
                        throw new Exception("                    The product cannot be placed in the cart!!");

                    Console.WriteLine();
                    Console.Write("                                    Go to cart page ? y/n: ");
                    var awnserCart = Console.ReadLine().ToUpper();

                    switch (awnserCart)
                    {
                        case "Y":
                            Console.Clear();
                            cartView.ShowCart(loggedInclient);
                            break;
                        case "N":
                            Console.Clear();
                            homeView.ShowNav();
                            Console.WriteLine();
                            productsView.ProductsPageView(loggedInclient);
                            break;
                        default:
                            Console.Clear();
                            homeView.ShowNav();
                            Console.WriteLine();
                            productsView.ProductsPageView(loggedInclient);
                            break;
                    }
                    break;

                case "N":
                    Console.Clear();
                    homeView.ShowNav();
                    productsView.ProductsPageView(loggedInclient);
                    break;
                default:
                    Console.Clear();
                    homeView.ShowNav();
                    Console.WriteLine();
                    productsView.ProductsPageView(loggedInclient);
                    break;
            }
        }
    }
}
