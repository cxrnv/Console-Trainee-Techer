using System;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.ProductsServices;
using SunnyBuy.Views;

namespace SunnyBuy
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientLoggedIn loggedInclient = new ClientLoggedIn();
            ProductsView productsView = new ProductsView();
            HomeView homeView = new HomeView();

            homeView.ShowHome();
            Console.WriteLine();
            productsView.ProductsPageView(loggedInclient);
        }
    }
}