using System;
using SunnyBuy.Views;

namespace SunnyBuy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsView productsView = new ProductsView();
            HomeView homeView = new HomeView();

            homeView.ShowHome();
            Console.WriteLine("Type the number of the page you want to go: ");
            productsView.ProductsCategoryView();
            
        }
    }
}
