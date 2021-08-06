using System;
using SunnyBuy.Services.CartServices;

namespace SunnyBuy.Views
{
    public class ProductView
    {
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

        public void AddProductCardView(string awnser, int id)
        {
            HomeView homeView = new HomeView();
            CartView cartView = new CartView();
            CartService cartService = new CartService();
            ProductsView productsView = new ProductsView();

            switch (awnser)
            {
                case "Y":/*
                    PurchaseView purchaseView = new PurchaseView();
                    Console.Clear();
                    purchaseView.PurchaseRegisterView();
                    */
                    if (cartService.PostProductCart(id))
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
                            cartView.ShowCart();
                            break;
                        case "N":
                            Console.Clear();
                            homeView.ShowNav();
                            Console.WriteLine();
                            productsView.ProductsPageView();
                            break;
                        default:
                            Console.Clear();
                            homeView.ShowNav();
                            Console.WriteLine();
                            productsView.ProductsPageView();
                            break;
                    }
                    break;

                case "N":
                    Console.Clear();
                    homeView.ShowNav();
                    productsView.ProductsPageView();
                    break;
                default:
                    Console.Clear();
                    homeView.ShowNav();
                    Console.WriteLine();
                    productsView.ProductsPageView();
                    break;
            }
        }
    }
}
